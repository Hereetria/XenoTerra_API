using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Reflection;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Utils;

using XenoTerra.WebAPI.Services.Common.DataLoading;
using XenoTerra.WebAPI.Services.Common.EntityAssignment;
using XenoTerra.WebAPI.Services.Common.EntityMapping;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Resolvers.Base
{
    public class EntityResolver<TEntity, TDtoResult, TKey> : IEntityResolver<TEntity, TDtoResult, TKey>
        where TEntity : class
        where TDtoResult : class
        where TKey : notnull
    {
        private readonly IEntityFieldMapBuilder<TEntity, TDtoResult, TKey> _entityFieldMapBuilder;
        private readonly IDataLoaderInvoker _dataLoaderInvoker;

        public EntityResolver(IEntityFieldMapBuilder<TEntity, TDtoResult, TKey> entityFieldMapBuilder, IDataLoaderInvoker dataLoaderInvoker)
        {
            _entityFieldMapBuilder = entityFieldMapBuilder;
            _dataLoaderInvoker = dataLoaderInvoker;
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
            var entityMaps = _entityFieldMapBuilder.Build(dtoResultList, context);

            foreach (var entry in entityMaps)
            {
                var entityType = entry.Key;
                var (entityIds, selectedFields) = entry.Value;
                var entityIdsList = entityIds?.Cast<object>().ToList() ?? new List<object>();

                var resultsDict = await _dataLoaderInvoker.InvokeLoadAsync(entityType, dbContext, entityIdsList, selectedFields.ToList())
                    ?? throw new InvalidOperationException("InvokeLoadAsync returned null.");

                var resultsDictType = resultsDict.GetType();

                if (!resultsDictType.IsGenericType || resultsDictType.GetGenericTypeDefinition() != typeof(Dictionary<,>))
                {
                    throw new InvalidOperationException($"InvokeGenericLoadAsync did not return a valid Dictionary<TKey, TValue>. Found: {resultsDictType}");
                }

                var genericArguments = resultsDictType.GetGenericArguments();
                var relatedEntityKeyType = genericArguments[0];
                var relatedEntityType = genericArguments[1];

                var assignmentServiceType = typeof(EntityAssignmentService<,,,>)
                    .MakeGenericType(typeof(TEntity), typeof(TDtoResult), relatedEntityType, relatedEntityKeyType);

                var assignmentService = Activator.CreateInstance(assignmentServiceType)
                    ?? throw new InvalidOperationException("EntityAssignmentService instance could not be created.");

                var assignMethod = assignmentServiceType.GetMethod(nameof(EntityAssignmentService<TEntity, TDtoResult, object, object>.AssignRelatedEntities))
                    ?? throw new InvalidOperationException("AssignRelatedEntities method not found.");

                assignMethod.Invoke(assignmentService, new object[] { dbContext, dtoResultList, resultsDict });

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


            var navigationProperties = typeof(TDtoResult)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(prop =>
                    prop.PropertyType == typeof(TRelatedDtoResult) ||
                    (prop.PropertyType.IsGenericType &&
                     prop.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>) &&
                     prop.PropertyType.GetGenericArguments()[0] == typeof(TRelatedDtoResult)))
                .ToList();

            List<(PropertyInfo fkProperty, PropertyInfo navigationProperty)> mappings = new();

            foreach (var navProperty in navigationProperties)
            {
                string? crossTableName = CrossTableNameProvider.GetCrossTableName<TEntity>(dbContext, navProperty.Name);
                if (crossTableName is null)
                {
                    bool dependentEntityType = TypeProviders.HasForeignKeyTo<TEntity>(dbContext, navProperty.Name);
                    var singularNavProperty = PluralWordProvider.ConvertToSingular(navProperty.Name);

                    if (dependentEntityType)
                    {
   
                    }
                    else
                    {
                        var fkPropName = TypeProviders.GetForeignKeyProperty<TRelatedEntity>(dbContext, singularNavProperty)?.Name;
                        if (fkPropName == null) continue;

                        var fkProperty = typeof(TRelatedDtoResult).GetProperty(fkPropName, BindingFlags.Public | BindingFlags.Instance);

                        if (fkProperty != null && fkProperty.PropertyType == typeof(TRelatedDtoResultKey))
                        {
                            mappings.Add((fkProperty, navProperty));
                        }

                        foreach (var resultDto in resultDtoList)
                        {
                            var resultDtoType = resultDto.GetType();
                            var primaryKey = resultDtoType.GetProperty("Id")?.GetValue(resultDto);

                            if (primaryKey == null)
                                continue;

                            foreach (var (mappingFkProperty, mappingNavProperty) in mappings)
                            {
                                var relatedEntity = resultsDict.Values
                                    .FirstOrDefault(entity => Equals(mappingFkProperty.GetValue(entity), primaryKey));

                                if (relatedEntity == null)
                                    continue;

                                var navType = mappingNavProperty.PropertyType;
                                bool isCollection = typeof(IEnumerable).IsAssignableFrom(navType)
                                                     && navType != typeof(string);

                                if (isCollection)
                                {
                                    var elementType = navType.IsGenericType
                                        ? navType.GetGenericArguments().First()
                                        : typeof(object);

                                    var list = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(elementType));
                                    list.Add(relatedEntity);
                                    mappingNavProperty.SetValue(resultDto, list);
                                }
                                else
                                {
                                    mappingNavProperty.SetValue(resultDto, relatedEntity);
                                }
                            }
                        }
                    }
                }
                else
                {
                    var entityKeyProperty = dbContext.Model.FindEntityType(typeof(TEntity))!
                        .FindPrimaryKey()!
                        .Properties.First();
                    var entityKeyPropertyName = entityKeyProperty.Name;

                    var dtoKeyProperty = typeof(TDtoResult).GetProperty(entityKeyPropertyName)

                        ?? throw new Exception($"DTO '{typeof(TDtoResult).Name}' does not contain '{entityKeyPropertyName}'");

                    var crossNavProp = typeof(TEntity).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                        .FirstOrDefault(p => string.Equals(p.Name, crossTableName, StringComparison.InvariantCultureIgnoreCase))
                        ?? throw new Exception($"'{crossTableName}' property not found on '{typeof(TEntity).Name}'");

                    var crossEntityType = crossNavProp.PropertyType.IsGenericType
                        ? crossNavProp.PropertyType.GetGenericArguments().First()
                        : crossNavProp.PropertyType;

                    var crossEntityEfType = dbContext.Model.FindEntityType(crossEntityType)
                        ?? throw new Exception($"Cross entity '{crossEntityType.Name}' not found in DbContext.");

                    var crossEntityKeys = crossEntityEfType.FindPrimaryKey()?.Properties;

                    if (crossEntityKeys == null || crossEntityKeys.Count != 2)
                        throw new Exception($"Cross table '{crossEntityType.Name}' must have exactly 2 primary keys.");

                    var relatedEntityKeyPropertyName = crossEntityKeys
                        .FirstOrDefault(k => !string.Equals(k.Name, entityKeyProperty.Name, StringComparison.InvariantCultureIgnoreCase))
                        ?.Name
                        ?? throw new Exception("Could not determine related entity key property.");

                    crossTableName = PluralWordProvider.ConvertToSingular(crossTableName);
                    var crossTableType = dbContext.Model.GetEntityTypes()
                        .FirstOrDefault(e => e.ClrType.Name.Equals(crossTableName, StringComparison.InvariantCultureIgnoreCase))
                        ?.ClrType
                        ?? throw new Exception($"Cross table '{crossTableName}' not found.");

                    var setMethod = typeof(DbContext).GetMethod(nameof(DbContext.Set), Type.EmptyTypes)!
                        .MakeGenericMethod(crossTableType);

                    var queryable = (IQueryable)setMethod.Invoke(dbContext, null)!;
                    var crossTableData = queryable.Cast<object>().ToList();

                    var entityIdToRelatedIds = new Dictionary<object, List<object>>();

                    foreach (var row in crossTableData)
                    {
                        var entityIdProp = crossTableType.GetProperty(entityKeyPropertyName);
                        var relatedIdProp = crossTableType.GetProperty(relatedEntityKeyPropertyName);

                        if (entityIdProp == null || relatedIdProp == null)
                            continue;

                        var entityId = entityIdProp.GetValue(row);
                        var relatedId = relatedIdProp.GetValue(row);

                        if (entityId == null || relatedId == null)
                            continue;

                        if (!entityIdToRelatedIds.TryGetValue(entityId, out var list))
                        {
                            list = new List<object>();
                            entityIdToRelatedIds[entityId] = list;
                        }

                        list.Add(relatedId);
                    }

                    var relatedKeyProperty = typeof(TRelatedDtoResult).GetProperty(relatedEntityKeyPropertyName)
                        ?? throw new Exception($"Related DTO '{typeof(TRelatedDtoResult).Name}' does not contain '{relatedEntityKeyPropertyName}'");

                    var relatedEntityDict = resultsDict.Values.ToDictionary(x => relatedKeyProperty.GetValue(x)!, x => x);

                    foreach (var resultDto in resultDtoList)
                    {
                        var entityId = dtoKeyProperty.GetValue(resultDto);
                        if (entityId == null)
                            continue;

                        if (!entityIdToRelatedIds.TryGetValue(entityId, out var relatedIdList))
                            continue;

                        var navType = navProperty.PropertyType;
                        var elementType = navType.IsGenericType
                            ? navType.GetGenericArguments().First()
                            : typeof(object);

                        var list = (System.Collections.IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(elementType));

                        foreach (var relatedId in relatedIdList)
                        {
                            if (relatedEntityDict.TryGetValue(relatedId, out var relatedEntity))
                            {
                                list.Add(relatedEntity);
                            }
                        }

                        navProperty.SetValue(resultDto, list);
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


            var entityMap = new Dictionary<Type, (HashSet<TKey> NavigationIds, HashSet<string> SelectedFields)>();

            foreach (var relationalField in relationalFields)
            {

                string? crossTableName = CrossTableNameProvider.GetCrossTableName<TEntity>(dbContext, relationalField);

                if (crossTableName is null)
                {
                    bool dependentEntityType = TypeProviders.HasForeignKeyTo<TEntity>(dbContext, relationalField);
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

                        var method = typeof(TypeProviders)
                            .GetMethod(nameof(TypeProviders.GetRelatedPrimaryKeysByForeignKeyMatch))!
                            .MakeGenericMethod(relatedEntityType, typeof(TKey)); // sadece method generic!


                        // 2. entityPrimaryKeys HashSet ise List'e çevir
                        var relatedEntityPrimaryKeys = method.Invoke(
                            this, // <-- IMPORTANT: instance method
                            new object[] { dbContext, foreignKeyProperty, entityPrimaryKeys.ToList() }
                        ) as IEnumerable<TKey>;



                        var nestedSelectedFields = new HashSet<string>(GraphQLFieldProvider.GetNestedSelectedFields(context, relationalField))
                            ?? throw new ArgumentNullException("nestedSelectedFields cannot be null");

                        nestedSelectedFields.Add(foreignKeyProperty.Name);

                        if (!nestedSelectedFields.Contains(foreignKeyProperty.Name))
                        {
                            nestedSelectedFields.Add(foreignKeyProperty.Name);
                        }

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













    }
}
