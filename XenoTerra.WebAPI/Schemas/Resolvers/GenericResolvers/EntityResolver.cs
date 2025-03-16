using AutoMapper;
using GreenDonut.DependencyInjection;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.DataLoaders;
using XenoTerra.WebAPI.Schemas.DataLoaders.Base;
using XenoTerra.WebAPI.Schemas.DataLoaders.DataLoaderFactories;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Resolvers.GenericResolvers
{
    public class EntityResolver<TEntity, TKey>
        where TEntity : class
        where TKey : notnull
    {
        private readonly EntityDataLoaderFactory _entityDataLoaderFactory;
        private readonly IMapper _mapper;

        public EntityResolver(EntityDataLoaderFactory entityDataLoaderFactory, IMapper mapper)
        {
            _entityDataLoaderFactory = entityDataLoaderFactory;
            _mapper = mapper;
        }

        public async Task PopulateRelatedFieldAsync(TEntity result, IResolverContext context)
        {
            await PopulateRelatedFieldsAsync(new List<TEntity> { result }, context);
        }

        public async Task PopulateRelatedFieldsAsync(
            List<TEntity> resultList,
            IResolverContext context)
        {
            var dbContext = context.Service<AppDbContext>();
            var entityMaps = GetEntityMap(resultList, context);

            foreach (var entry in entityMaps)
            {
                var entityType = entry.Key;
                var (entityIds, selectedFields) = entry.Value;

                var resultsDict = await InvokeGenericLoadAsync(entityType, dbContext, entityIds, selectedFields)
                    ?? throw new InvalidOperationException("InvokeGenericLoadAsync returned null.");

                var resultsDictType = resultsDict.GetType();

                if (!resultsDictType.IsGenericType || resultsDictType.GetGenericTypeDefinition() != typeof(Dictionary<,>))
                {
                    throw new InvalidOperationException($"InvokeGenericLoadAsync did not return a valid Dictionary<TKey, TValue>. Found: {resultsDictType}");
                }

                var genericArguments = resultsDictType.GetGenericArguments();
                var relatedEntityKeyType = genericArguments[0];
                var relatedEntityType = genericArguments[1]; 

                var assignMethod = typeof(EntityResolver<TEntity, TKey>)
                    .GetMethod(nameof(AssignRelatedEntities), BindingFlags.NonPublic | BindingFlags.Instance)
                    ?.MakeGenericMethod(relatedEntityKeyType, relatedEntityType)
                    ?? throw new InvalidOperationException($"AssignRelatedEntities method not found for {relatedEntityKeyType} and {relatedEntityType}.");

                assignMethod.Invoke(this, new object[] { dbContext, resultList, resultsDict });
            }

        }

        private List<TEntity> AssignRelatedEntities<TRelatedEntityKey, TRelatedEntity>(
            AppDbContext dbContext,
            List<TEntity> resultList,
            IReadOnlyDictionary<TRelatedEntityKey, TRelatedEntity> resultsDict)
            where TRelatedEntity : class
            where TRelatedEntityKey : notnull
        {
            var fkProperties = typeof(TEntity)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(prop => prop.PropertyType == typeof(TRelatedEntity))
                .ToList();

            List<(PropertyInfo fkProperty, PropertyInfo relatedProperty)> mappings = new();

            foreach (var fkProperty in fkProperties)
            {
                var fkPropertyInfo = TypeProviders.GetForeignKeyProperty<TEntity>(dbContext, fkProperty.Name);

                if (fkPropertyInfo != null)
                {
                    var relatedProperty = typeof(TEntity)
                        .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                        .FirstOrDefault(prop => prop.PropertyType == typeof(TRelatedEntity) && prop.Name.Contains(fkProperty.Name.Replace("Id", "")));

                    if (relatedProperty != null)
                    {
                        mappings.Add((fkPropertyInfo, relatedProperty));
                    }
                }
            }

            foreach (var entity in resultList)
            {
                foreach (var (fkProperty, relatedProperty) in mappings)
                {
                    object? rawValue = fkProperty.GetValue(entity);

                    if (rawValue != null && resultsDict.TryGetValue((TRelatedEntityKey)rawValue, out var relatedEntity))
                    {
                        relatedProperty.SetValue(entity, relatedEntity);
                    }
                }
            }

            return resultList;
        }

        private Dictionary<Type, (HashSet<TKey>, HashSet<string>)> GetEntityMap(
            List<TEntity> resultEntityList,
            IResolverContext context)
        {
            var dbContext = context.Service<AppDbContext>();
            var relationalFields = GraphQLFieldProvider.GetRelationalFields(context);

            var entityMap = new Dictionary<Type, (HashSet<TKey> NavigationIds, HashSet<string> SelectedFields)>();

            foreach (var relationalField in relationalFields)
            {
                PropertyInfo entityProperty = typeof(TEntity)
                    .GetProperties()
                    .FirstOrDefault(p => p.Name.Equals(relationalField, StringComparison.OrdinalIgnoreCase))
                    ?? throw new Exception($"Property '{relationalField}' not found in {typeof(TEntity).Name}");

                Type entityType = entityProperty.PropertyType;

                PropertyInfo foreignKeyProperty = TypeProviders.GetForeignKeyProperty<TEntity>(dbContext, relationalField)
                    ?? throw new Exception($"Foreign key property not found for '{relationalField}' in DTO.");

                var navigationIds = resultEntityList
                    .Select(e => foreignKeyProperty.GetValue(e))
                    .Where(value => value is TKey)
                    .Cast<TKey>()
                    .ToHashSet();


                var nestedSelectedFields = GraphQLFieldProvider.GetNestedSelectedFields(context, relationalField);

                if (!entityMap.TryGetValue(entityType, out var entityData))
                {
                    entityData = (new HashSet<TKey>(), new HashSet<string>());
                    entityMap[entityType] = entityData;
                }

                entityData.NavigationIds.UnionWith(navigationIds);
                entityData.SelectedFields.UnionWith(nestedSelectedFields);
            }

            return entityMap;
        }

        private async Task<object> InvokeGenericLoadAsync(Type entityType, AppDbContext dbContext, HashSet<TKey> entityIds, HashSet<string> selectedFields)
        {
            var keyType = TypeProviders.GetPrimaryKeyProperty(dbContext, entityType).PropertyType
                ?? throw new InvalidOperationException($"Could not determine primary key type for entity: {entityType}");

            var getDataLoaderMethod = typeof(EntityDataLoaderFactory)
                .GetMethod(nameof(EntityDataLoaderFactory.GetDataLoader))
                ?? throw new InvalidOperationException("GetDataLoader method not found in EntityDataLoaderFactory.");


            var genericGetDataLoadermethod = getDataLoaderMethod.MakeGenericMethod(entityType, keyType);

            var loaderInstance = genericGetDataLoadermethod.Invoke(_entityDataLoaderFactory, null)
                ?? throw new InvalidOperationException($"Failed to create data loader instance for {entityType} with key type {keyType}");

            var loadAsyncMethod = loaderInstance.GetType().GetMethod(
                nameof(IEntityDataLoader<object, object>.LoadAsync),
                new[] { typeof(List<TKey>), typeof(List<string>) })
                ?? throw new InvalidOperationException($"LoadAsync method with signature 'public async Task<IReadOnlyDictionary<TKey, TRelatedEntity>> LoadAsync(List<TKey> keys, List<string> selectedFields)' not found for {entityType}");

            var keysList = entityIds.ToList();
            var fieldsList = selectedFields.ToList();

            if (loadAsyncMethod.Invoke(loaderInstance, new object[] { keysList, fieldsList }) is not Task task)
            {
                throw new InvalidOperationException("LoadAsync invocation did not return a valid Task.");
            }

            await task.ConfigureAwait(false);

            var resultProperty = task.GetType().GetProperty("Result")
                ?? throw new InvalidOperationException("Result property not found on LoadAsync task.");

            return resultProperty.GetValue(task)
                ?? throw new InvalidOperationException("LoadAsync result is null.");
        }
    }
}
