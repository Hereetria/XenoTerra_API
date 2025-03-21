using AutoMapper;
using GreenDonut;
using GreenDonut.DependencyInjection;
using HotChocolate.Resolvers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.DTOLayer.Dtos.UserDtos;
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
                    ?.MakeGenericMethod(entityType, relatedEntityType, relatedEntityKeyType)
                    ?? throw new InvalidOperationException($"AssignRelatedEntities method not found for {relatedEntityKeyType} and {relatedEntityType}.");

                assignMethod.Invoke(this, new object[] { dbContext, dtoResultList, resultsDict });
            }

        }

        private List<TDtoResult> AssignRelatedEntities<TRelatedEntity, TRelatedDtoResult, TRelatedDtoResultKey>(
            AppDbContext dbContext,
            List<TDtoResult> resultDtoList,
            IReadOnlyDictionary<TRelatedDtoResultKey, TRelatedDtoResult> resultsDict)
            where TRelatedEntity : class
            where TRelatedDtoResult : class
            where TRelatedDtoResultKey : notnull
        {
            var entityType = dbContext.Model.FindEntityType(typeof(TEntity))
                ?? throw new Exception($"Entity '{typeof(TEntity).Name}' not found in DbContext.");

            string? crossTableName = null;
            // Her bir resultDto içindeki ilişki atanacak property'leri bul
            var navigationProperties = typeof(TDtoResult)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(prop =>
                    prop.PropertyType == typeof(TRelatedDtoResult) ||
                    (prop.PropertyType.IsGenericType &&
                     prop.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>) &&
                     prop.PropertyType.GetGenericArguments()[0] == typeof(TRelatedDtoResult))
                )
                .ToList();


            // Eşleşen (FK property - navigation property) çiftlerini bul
            List<(PropertyInfo fkProperty, PropertyInfo navigationProperty)> mappings = new();

            foreach (var navProperty in navigationProperties)
            {
                if (crossTableName is null)
                {
                    bool dependentEntityType = HasForeignKeyTo(dbContext, navProperty.Name);
                    if (dependentEntityType)
                    {
                        var fkPropName = TypeProviders.GetForeignKeyProperty<TEntity>(dbContext, navProperty.Name)?.Name;
                        if (fkPropName == null) continue;

                        var fkProperty = typeof(TDtoResult)
                            .GetProperty(fkPropName, BindingFlags.Public | BindingFlags.Instance);

                        if (fkProperty != null && fkProperty.PropertyType == typeof(TRelatedDtoResultKey))
                        {
                            mappings.Add((fkProperty, navProperty));
                        }

                    }
                    else
                    {

                    }
                }
                else
                {
                    // crossTableName durumu için logic buraya eklenecek
                }
 
            }
            foreach (var resultDto in resultDtoList)
            {
                foreach (var (fkProperty, navProperty) in mappings)
                {
                    var rawValue = fkProperty.GetValue(resultDto);

                    if (rawValue is TRelatedDtoResultKey key && resultsDict.TryGetValue(key, out var relatedEntity))
                    {
                        navProperty.SetValue(resultDto, relatedEntity);
                    }
                }
            }

            return resultDtoList;
        }


        private Dictionary<Type, (HashSet<TKey>, HashSet<string>)> GetEntityMap(
            IEnumerable<TDtoResult> resultEntityList,
            IResolverContext context)
        {
            var dbContext = context.Service<AppDbContext>();
            var relationalFields = GraphQLFieldProvider.GetRelationalFields(context);

            var entityType = dbContext.Model.FindEntityType(typeof(TEntity))
                ?? throw new Exception($"Entity '{typeof(TEntity).Name}' not found in DbContext.");

            string? crossTableName =null;


            var entityMap = new Dictionary<Type, (HashSet<TKey> NavigationIds, HashSet<string> SelectedFields)>();

            foreach (var relationalField in relationalFields)
            {
                
                if (crossTableName is null)
                {
                    bool dependentEntityType = HasForeignKeyTo(dbContext, relationalField);
                    if (dependentEntityType)
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
                        entityType = dbContext.Model.FindEntityType(typeof(TEntity))
                            ?? throw new InvalidOperationException($"Entity '{typeof(TEntity).Name}' not found in DbContext.");

                        var keyProperty = entityType.FindPrimaryKey()?.Properties.FirstOrDefault()
                            ?? throw new InvalidOperationException($"Primary key not found for '{typeof(TEntity).Name}'.");

                        var keyPropertyName = keyProperty.Name;

                        // DTO üzerindeki aynı isimli key property'yi bul
                        var dtoKeyProperty = typeof(TDtoResult).GetProperty(keyPropertyName)
                            ?? throw new InvalidOperationException($"DTO '{typeof(TDtoResult).Name}' does not contain property '{keyPropertyName}'.");

                        // DTO listesi içinden PK değerlerini çek
                        var entityPrimaryKeys = resultEntityList
                            .Select(e => dtoKeyProperty.GetValue(e))
                            .Where(v => v is TKey)
                            .Cast<TKey>()
                            .ToHashSet();

                        var rawType = typeof(TEntity)
                            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                            .FirstOrDefault(p => string.Equals(p.Name, relationalField, StringComparison.InvariantCultureIgnoreCase))
                            ?.PropertyType
                            ?? throw new InvalidOperationException($"Property '{relationalField}' not found on DTO type '{typeof(TEntity).Name}'.");

                        // Eğer ICollection<T> veya IEnumerable<T> ise iç tipini al
                        var relatedEntityType = rawType.IsGenericType &&
                                                typeof(IEnumerable).IsAssignableFrom(rawType) &&
                                                rawType != typeof(string)
                            ? rawType.GetGenericArguments().First()
                            : rawType;

                        var methodInfo = typeof(TypeProviders)
                            .GetMethods(BindingFlags.Public | BindingFlags.Static)
                            .First(m => m.Name == "GetForeignKeyProperty" && m.IsGenericMethod);

                        var concreteGenericMethod = methodInfo.MakeGenericMethod(relatedEntityType);

                        string singleRelationalField = PluralWordProvider.ConvertToSingular(relationalField);
                        if (concreteGenericMethod.Invoke(null, new object[] { dbContext, singleRelationalField, crossTableName }) is not PropertyInfo foreignKeyProperty)
                        {
                            throw new Exception($"Foreign key property not found for '{relationalField}' in entity '{relatedEntityType.Name}'.");
                        }

                        var method = typeof(EntityResolver<,,>)
                            .MakeGenericType(typeof(TEntity), typeof(TDtoResult), typeof(TKey))
                            .GetMethod(nameof(GetRelatedPrimaryKeysByForeignKeyMatch))!
                            .MakeGenericMethod(relatedEntityType);

                        // 2. entityPrimaryKeys HashSet ise List'e çevir
                        var relatedEntityPrimaryKeys = method.Invoke(
                            this, // <-- IMPORTANT: instance method
                            new object[] { dbContext, foreignKeyProperty, entityPrimaryKeys.ToList() }
                        ) as IEnumerable<TKey>;



                        var nestedSelectedFields = GraphQLFieldProvider.GetNestedSelectedFields(context, relationalField);

                        if (!entityMap.TryGetValue(relatedEntityType, out var entityData))
                        {
                            entityData = (new HashSet<TKey>(), new HashSet<string>());
                            entityMap[relatedEntityType] = entityData;
                        }

                        entityData.NavigationIds.UnionWith(relatedEntityPrimaryKeys);
                        entityData.SelectedFields.UnionWith(nestedSelectedFields);
                    }


                }
                else
                {
                    var pluralCrossTableName = PluralWordProvider.ConvertToPlural("crossTableName");

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

        public static List<TKey> GetRelatedPrimaryKeysByForeignKeyMatch<TRelatedEntity>(
    DbContext dbContext,
    PropertyInfo foreignKeyProperty,
    List<TKey> entityPrimaryKeys
) where TRelatedEntity : class
        {
            if (foreignKeyProperty == null)
                throw new ArgumentNullException(nameof(foreignKeyProperty));
            if (entityPrimaryKeys == null || !entityPrimaryKeys.Any())
                return new List<TKey>();

            var entityType = dbContext.Model.FindEntityType(typeof(TRelatedEntity));
            var primaryKeyProp = entityType.FindPrimaryKey().Properties.First().PropertyInfo;

            var allEntities = dbContext.Set<TRelatedEntity>().ToList();

            var matchingPrimaryKeys = new List<TKey>();

            foreach (var entity in allEntities)
            {
                var foreignKeyValue = foreignKeyProperty.GetValue(entity);
                if (foreignKeyValue is TKey key && entityPrimaryKeys.Contains(key))
                {
                    var primaryKeyValue = primaryKeyProp.GetValue(entity);
                    if (primaryKeyValue is TKey pk)
                        matchingPrimaryKeys.Add(pk);
                }
            }

            return matchingPrimaryKeys;
        }

        public static bool HasForeignKeyTo(AppDbContext dbContext, string targetEntityPropertyName)
        {
            var entityType = dbContext.Model.FindEntityType(typeof(TEntity))
                ?? throw new InvalidOperationException($"Entity '{typeof(TEntity).Name}' not found in DbContext.");

            // TEntity içindeki property'nin tipini bul
            var targetProperty = typeof(TEntity).GetProperty(targetEntityPropertyName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase)
                ?? throw new ArgumentException($"Property '{targetEntityPropertyName}' not found on '{typeof(TEntity).Name}'.");

            var targetPropertyType = targetProperty.PropertyType;

            var foreignKeys = entityType.GetForeignKeys();

            foreach (var fk in foreignKeys)
            {
                var principalEntityType = fk.PrincipalEntityType.ClrType;

                if (principalEntityType == targetPropertyType)
                {
                    return true;
                }
            }

            return false;
        }




        private string? GetCrossTableName(AppDbContext dbContext, string targetEntityName)
        {
            var entityType = typeof(TEntity);
            var navigationProps = entityType
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.PropertyType.IsGenericType &&
                            p.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>))
                .Select(p => p.PropertyType.GetGenericArguments().First())
                .ToList();

            foreach (var potentialJoinEntity in navigationProps)
            {
                var joinEntityProps = potentialJoinEntity.GetProperties(BindingFlags.Public | BindingFlags.Instance);

                bool hasSource = joinEntityProps.Any(p =>
                    p.PropertyType == entityType ||
                    (p.PropertyType.IsGenericType &&
                     p.PropertyType.GetGenericArguments().Contains(entityType)));

                bool hasTarget = joinEntityProps.Any(p =>
                    string.Equals(p.PropertyType.Name, targetEntityName, StringComparison.InvariantCultureIgnoreCase) ||
                    (p.PropertyType.IsGenericType &&
                     p.PropertyType.GetGenericArguments().Any(t =>
                         string.Equals(t.Name, targetEntityName, StringComparison.InvariantCultureIgnoreCase))));

                if (hasSource && hasTarget)
                {
                    return potentialJoinEntity.Name;
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
