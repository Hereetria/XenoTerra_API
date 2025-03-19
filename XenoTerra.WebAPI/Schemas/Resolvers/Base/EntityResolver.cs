using AutoMapper;
using GreenDonut.DependencyInjection;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.DataLoaders;
using XenoTerra.WebAPI.Schemas.DataLoaders.Base;
using XenoTerra.WebAPI.Schemas.DataLoaders.DataLoaderFactories;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Resolvers.Base
{
    public class EntityResolver<TEntity, TDtoResult, TKey> : IEntityResolver<TEntity, TDtoResult, TKey>
        where TEntity : class
        where TDtoResult : class
        where TKey : notnull
    {
        private readonly EntityDataLoaderFactory _entityDataLoaderFactory;

        public EntityResolver(EntityDataLoaderFactory entityDataLoaderFactory)
        {
            _entityDataLoaderFactory = entityDataLoaderFactory;
        }

        public async Task PopulateRelatedFieldAsync(TDtoResult result, IResolverContext context)
        {
            await PopulateRelatedFieldsAsync(new List<TDtoResult> { result }, context);
        }

        public async Task PopulateRelatedFieldsAsync(
            IEnumerable<TDtoResult> dtoResultList,
            IResolverContext context)
        {
            var dbContext = context.Service<AppDbContext>();
            var entityMaps = GetEntityMap(dtoResultList, context);

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

                var assignMethod = typeof(EntityResolver<TEntity, TDtoResult, TKey>)
                    .GetMethod(nameof(AssignRelatedEntities), BindingFlags.NonPublic | BindingFlags.Instance)
                    ?.MakeGenericMethod(relatedEntityKeyType, relatedEntityType)
                    ?? throw new InvalidOperationException($"AssignRelatedEntities method not found for {relatedEntityKeyType} and {relatedEntityType}.");

                assignMethod.Invoke(this, new object[] { dbContext, dtoResultList, resultsDict });
            }

        }

        private List<TDtoResult> AssignRelatedEntities<TRelatedDtoResultKey, TRelatedDtoResult>(
            AppDbContext dbContext,
            List<TDtoResult> resultList,
            IReadOnlyDictionary<TRelatedDtoResultKey, TRelatedDtoResult> resultsDict)
            where TRelatedDtoResult : class
            where TRelatedDtoResultKey : notnull
        {
            var entityType = dbContext.Model.FindEntityType(typeof(TEntity))
                ?? throw new Exception($"Entity '{typeof(TEntity).Name}' not found in DbContext.");

            string? crossTableName = GetCrossTableName(dbContext, typeof(TEntity));
            if (crossTableName is null)
            {
                //Buradan devam et
                var fkProperties = typeof(TDtoResult)
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(prop =>
                        string.Equals(prop.PropertyType.Name, typeof(TRelatedDtoResult).Name, StringComparison.OrdinalIgnoreCase) || // Non-nullable eşleşme
                        (Nullable.GetUnderlyingType(prop.PropertyType) != null &&
                         string.Equals(Nullable.GetUnderlyingType(prop.PropertyType).Name, typeof(TRelatedDtoResult).Name, StringComparison.OrdinalIgnoreCase)) // Nullable eşleşme
                    )
                    .ToList();



                List<(PropertyInfo fkProperty, PropertyInfo relatedProperty)> mappings = new();

                foreach (var fkProperty in fkProperties)
                {
                    var fkPropertyInfo = TypeProviders.GetForeignKeyProperty<TRelatedDtoResult>(dbContext, fkProperty.Name);

                    if (fkPropertyInfo != null)
                    {
                        var relatedProperty = typeof(TRelatedDtoResult)
                            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                            .FirstOrDefault(prop => prop.PropertyType == typeof(TRelatedDtoResult) && prop.Name.Contains(fkProperty.Name.Replace("Id", "")));

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

                        if (rawValue != null && resultsDict.TryGetValue((TRelatedDtoResultKey)rawValue, out var relatedEntity))
                        {
                            relatedProperty.SetValue(entity, relatedEntity);
                        }
                    }
                }
            }
            else
            {
                var crossTableMap = new Dictionary<Guid, HashSet<Guid>>();
                foreach (var resultField in resultList)
                {
                    var entityPrimaryKey = entityType.FindPrimaryKey()
                        ?? throw new InvalidOperationException("Primary key not found");

                    var entityPrimaryKeyProperty = entityPrimaryKey.Properties.FirstOrDefault()
                        ?? throw new InvalidOperationException("Primary key could'nt taked");

                    var entityCrossTableProperty = entityType.GetProperties().FirstOrDefault(p => p.Name == crossTableName)
                        ?? throw new Exception($"Property '{crossTableName}' not found in entity '{entityType.Name}'.");

                    var entityPrimaryKeyValue = entityPrimaryKeyProperty?.PropertyInfo?.GetValue(resultField)
                        ?? throw new ArgumentNullException($"EntityPrimaryKeyValue not found in {resultField}");

                    var crossTableCollection = entityCrossTableProperty?.PropertyInfo?.GetValue(resultField) as IEnumerable<object>;
                    if (crossTableCollection == null)
                        continue;

                    Type crossTableItemType = entityCrossTableProperty.PropertyInfo.PropertyType.GetGenericArguments().First();
                    var newCrossTableCollection = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(crossTableItemType));



                }


            }

            return resultList;
        }

        private Dictionary<Type, (HashSet<TKey>, HashSet<string>)> GetEntityMap(
            IEnumerable<TDtoResult> resultEntityList,
            IResolverContext context)
        {
            var dbContext = context.Service<AppDbContext>();
            var relationalFields = GraphQLFieldProvider.GetRelationalFields(context);

            var entityType = dbContext.Model.FindEntityType(typeof(TEntity))
                ?? throw new Exception($"Entity '{typeof(TEntity).Name}' not found in DbContext.");

            string? crossTableName = GetCrossTableName(dbContext, typeof(TEntity));


            var entityMap = new Dictionary<Type, (HashSet<TKey> NavigationIds, HashSet<string> SelectedFields)>();

            foreach (var relationalField in relationalFields)
            {
                if (crossTableName is null)
                {
                    PropertyInfo entityProperty = typeof(TEntity)
                    .GetProperties()
                    .FirstOrDefault(p => p.Name.Equals(relationalField, StringComparison.OrdinalIgnoreCase))
                    ?? throw new Exception($"Property '{relationalField}' not found in {typeof(TEntity).Name}");

                    Type entityPropertyType = entityProperty.PropertyType;

                    PropertyInfo entityForeignKeyProperty = TypeProviders.GetForeignKeyProperty<TEntity>(dbContext, relationalField)
                        ?? throw new Exception($"Foreign key property not found for '{relationalField}' in DTO.");

                    PropertyInfo dtoForeignKeyProperty = typeof(TDtoResult)
                        .GetProperties()
                        .FirstOrDefault(p => p.Name.Equals(entityForeignKeyProperty.Name, StringComparison.OrdinalIgnoreCase))
                        ?? throw new ArgumentNullException($"{entityForeignKeyProperty} not found in the {typeof(TDtoResult)} class");

                    var navigationIds = resultEntityList
                        .Select(e => dtoForeignKeyProperty.GetValue(e))
                        .Where(value => value is TKey)
                        .Cast<TKey>()
                        .ToHashSet();


                    var nestedSelectedFields = GraphQLFieldProvider.GetNestedSelectedFields(context, relationalField);

                    if (!entityMap.TryGetValue(entityPropertyType, out var entityData))
                    {
                        entityData = (new HashSet<TKey>(), new HashSet<string>());
                        entityMap[entityPropertyType] = entityData;
                    }

                    entityData.NavigationIds.UnionWith(navigationIds);
                    entityData.SelectedFields.UnionWith(nestedSelectedFields);
                }
                else
                {
                    var pluralCrossTableName = PluralWordProvider.ConvertToPlural(crossTableName);

                    PropertyInfo navigationProperty = typeof(TEntity)
                        .GetProperties()
                        .FirstOrDefault(p => string.Equals(p.Name, pluralCrossTableName, StringComparison.OrdinalIgnoreCase))
                        ?? throw new ArgumentNullException($"Navigation property '{pluralCrossTableName}' not found in entity '{typeof(TEntity).Name}'.");

                    Type navigationPropertyType = navigationProperty.PropertyType;

                    if (navigationPropertyType.IsGenericType && navigationPropertyType.GetGenericTypeDefinition() == typeof(ICollection<>))
                    {
                        navigationPropertyType = navigationPropertyType.GetGenericArguments().First();
                    }

                    var entityPrimaryKeyProperty = entityType.FindPrimaryKey()?.Properties.FirstOrDefault()
                        ?? throw new Exception($"Primary key not found for entity '{typeof(TEntity).Name}'.");

                    string entityPrimaryKeyName = entityPrimaryKeyProperty.Name;

                    var navigationEntityType = dbContext.Model.FindEntityType(navigationPropertyType)
                        ?? throw new ArgumentNullException($"Entity '{navigationPropertyType}' not found in DbContext.");

                    var navigationPrimaryKeys = navigationEntityType.FindPrimaryKey()?.Properties.Select(p => p.Name).ToList()
                        ?? throw new Exception($"Primary keys not found for entity '{navigationPropertyType.Name}'.");

                    var targetPrimaryKey = navigationPrimaryKeys
                        .FirstOrDefault(pk => !pk.Equals(entityPrimaryKeyName, StringComparison.OrdinalIgnoreCase))
                        ?? throw new Exception("Target primary key not found.");

                    var navigationIds = resultEntityList
                        .Select(entity => entity.GetType().GetProperty(entityPrimaryKeyName)?.GetValue(entity))
                        .Where(value => value != null)
                        .Distinct()
                        .ToList();

                    var typedNavigationIds = navigationIds.Cast<TKey>().ToHashSet();

                    var setMethod = typeof(DbContext).GetMethod(nameof(DbContext.Set), Type.EmptyTypes)
                        ?.MakeGenericMethod(navigationPropertyType);

                    if (setMethod == null)
                        throw new Exception("Could not find the generic Set<TEntity> method on DbContext.");

                    // DbSet<TEntity> çağrısını runtime'da yap
                    var dbSet = setMethod.Invoke(dbContext, null);
                    if (dbSet == null)
                        throw new Exception($"Could not retrieve DbSet<{navigationPropertyType.Name}> from DbContext.");

                    // DbSet'i IQueryable<TEntity> türüne cast et
                    var queryable = dbSet as IQueryable;
                    if (queryable == null)
                        throw new Exception($"Could not cast DbSet<{navigationPropertyType.Name}> to IQueryable.");

                    var relatedTargetPrimaryKeys = ((IQueryable<object>)queryable)
                        .Where(e => navigationIds.Contains(EF.Property<object>(e, entityPrimaryKeyName)))
                        .Select(e => EF.Property<object>(e, targetPrimaryKey))
                        .Distinct()
                        .ToList();

                    var singularRelatedField = PluralWordProvider.ConvertToSingular(relationalField);

                    PropertyInfo relatedProperty = navigationPropertyType
                        .GetProperties()
                        .FirstOrDefault(p => string.Equals(p.Name, singularRelatedField, StringComparison.OrdinalIgnoreCase))
                        ?? throw new Exception($"Property '{singularRelatedField}' not found in entity '{navigationPropertyType.Name}'.");

                    Type relatedPropertyType = relatedProperty.PropertyType;

                    var typedRelatedTargetPrimaryKeys = relatedTargetPrimaryKeys.Cast<TKey>().ToHashSet();

                    var nestedSelectedFields = GraphQLFieldProvider.GetNestedSelectedFields(context, relationalField);

                    if (!entityMap.TryGetValue(relatedPropertyType, out var entityData))
                    {
                        entityData = (new HashSet<TKey>(), new HashSet<string>());
                        entityMap[relatedPropertyType] = entityData;
                    }

                    entityData.NavigationIds.UnionWith(typedRelatedTargetPrimaryKeys);
                    entityData.SelectedFields.UnionWith(nestedSelectedFields);
                }


            }

            return entityMap;
        }

        private string? GetCrossTableName(AppDbContext dbContext, Type entityType)
        {
            var crossTableEntities = dbContext.Model.GetEntityTypes()
                .Where(e => e.FindPrimaryKey()?.Properties.Count == 2)
                .ToList();

            foreach (var crossTable in crossTableEntities)
            {
                var properties = crossTable.ClrType.GetProperties();

                if (properties.Any(p => string.Equals(p.PropertyType.Name, entityType.Name, StringComparison.InvariantCultureIgnoreCase) ||
                                        (p.PropertyType.IsGenericType &&
                                         p.PropertyType.GetGenericArguments().Any(t =>
                                             string.Equals(t.Name, entityType.Name, StringComparison.InvariantCultureIgnoreCase)))))
                {
                    return crossTable.ClrType.Name;
                }
            }

            return null;
        }




        private async Task<object> InvokeGenericLoadAsync(Type entityType, AppDbContext dbContext, HashSet<TKey> entityIds, HashSet<string> selectedFields)
        {
            var getDataLoaderMethod = typeof(EntityDataLoaderFactory)
                .GetMethod(nameof(EntityDataLoaderFactory.GetDataLoader))
                ?? throw new InvalidOperationException("GetDataLoader method not found in EntityDataLoaderFactory.");


            var genericGetDataLoadermethod = getDataLoaderMethod.MakeGenericMethod(entityType);

            var loaderInstance = genericGetDataLoadermethod.Invoke(_entityDataLoaderFactory, null)
                ?? throw new InvalidOperationException($"Failed to create data loader instance for {entityType}");

            var loadAsyncMethod = loaderInstance.GetType().GetMethod(
                nameof(EntityDataLoader<object, object, object>.LoadAsync),
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
