using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.WebAPI.Utils;
using GreenDonut;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DataAccessLayer.Persistence;
using System.Linq;

namespace XenoTerra.WebAPI.Services.Common.EntityMapping
{
    public class EntityFieldMapBuilder<TEntity, TKey> : IEntityFieldMapBuilder<TEntity, TKey>
        where TEntity : class
        where TKey : notnull
    {
        private readonly Dictionary<Type, List<TKey>> _entityKeyMap = [];
        private readonly HashSet<TKey> _idsCache = [];
        public Dictionary<Type, (HashSet<TKey>, HashSet<string>)> Build(
            IEnumerable<TEntity> entityList,
            IResolverContext context,
            AppDbContext dbContext)
        {
            var relationalFields = GraphQLFieldProvider.GetRelationalFields(context);
            var entityMap = new Dictionary<Type, (HashSet<TKey>, HashSet<string>)>();

            foreach (var field in relationalFields)
            {
                var crossTableName = CrossTableNameProvider.GetCrossTableName<TEntity>(dbContext, field);

                if (crossTableName != null)
                {
                    HandleManyToMany(dbContext, entityList, field, crossTableName, entityMap, context);
                }
                else if (TypeProviders.HasForeignKeyTo<TEntity>(dbContext, field))
                {
                    HandleManyToOne(dbContext, entityList, field, entityMap, context);
                }
                else
                {
                    HandleOneToMany(dbContext, entityList, field, entityMap, context);
                }
            }
            _idsCache.Clear();
            _entityKeyMap.Clear();

            return entityMap;
        }

        private static void HandleManyToOne(
            AppDbContext dbContext,
            IEnumerable<TEntity> entityList,
            string field,
            Dictionary<Type, (HashSet<TKey>, HashSet<string>)> entityMap,
            IResolverContext context)
        {
            var entityProperty = typeof(TEntity)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .FirstOrDefault(p => string.Equals(p.Name, field, StringComparison.InvariantCultureIgnoreCase))
                ?? throw new Exception($"Property '{field}' not found in {typeof(TEntity).Name}");

            var foreignKeyProperty = TypeProviders.GetForeignKeyProperty<TEntity>(dbContext, field)
                ?? throw new Exception($"Foreign key property not found for '{field}'");

            var ids = entityList
                .Select(e => foreignKeyProperty.GetValue(e))
                .Where(x => x is TKey)
                .Cast<TKey>()
                .ToHashSet();

            var selectedFields = GraphQLFieldProvider
                .GetNestedSelectedFields(context, field)
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            if (!selectedFields.Contains(foreignKeyProperty.Name))
                selectedFields.Add(foreignKeyProperty.Name);

            AddOrUpdateMap(entityMap, entityProperty.PropertyType, ids, selectedFields);
        }

        private void HandleOneToMany(
            AppDbContext dbContext,
            IEnumerable<TEntity> entityList,
            string field,
            Dictionary<Type, (HashSet<TKey>, HashSet<string>)> entityMap,
            IResolverContext context)
        {
            var entityType = dbContext.Model.FindEntityType(typeof(TEntity))!;
            var pkProp = TypeProviders.GetPrimaryKeyProperty<TEntity>(dbContext);

            var primaryKeys = entityList
                .Select(e => pkProp.GetValue(e))
                .Where(x => x is TKey)
                .Cast<TKey>()
                .ToHashSet();

            var navProperty = typeof(TEntity)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .FirstOrDefault(p => string.Equals(p.Name, field, StringComparison.InvariantCultureIgnoreCase))
                ?? throw new Exception($"Property '{field}' not found on entity '{typeof(TEntity).Name}'");

            var navType = navProperty.PropertyType;
            var relatedType = navType.IsGenericType && navType != typeof(string)
                ? navType.GetGenericArguments().First()
                : navType;

            var getFkMethod = typeof(TypeProviders)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .First(m => m.Name == nameof(TypeProviders.GetForeignKeyProperty) && m.IsGenericMethod);

            var genericFkMethod = getFkMethod.MakeGenericMethod(relatedType);

            var singularField = PluralWordProvider.ConvertToSingular(field);

            var fkProp = genericFkMethod.Invoke(null, [dbContext, singularField, null]) as PropertyInfo
                ?? throw new InvalidOperationException($"Foreign key property not found on related entity '{relatedType.Name}'.");

            var method = typeof(TypeProviders)
                .GetMethod(nameof(TypeProviders.GetRelatedPrimaryKeysByForeignKeyMatch))!
                .MakeGenericMethod(relatedType, typeof(TKey));

            if (!_entityKeyMap.TryGetValue(relatedType, out var relatedIds))
            {
                var result = method.Invoke(
                    null,
                    [dbContext, fkProp, primaryKeys.ToList()]
                ) as List<TKey>;

                if (result is not List<TKey> resolved)
                {
                    throw new InvalidOperationException("Failed to invoke method or unexpected return type.");
                }

                relatedIds = resolved;
                _entityKeyMap[relatedType] = relatedIds;
            }

            var selectedFieldsRaw = GraphQLFieldProvider.GetNestedSelectedFields(context, field);

            var selectedFields = selectedFieldsRaw != null
                ? new HashSet<string>(selectedFieldsRaw, StringComparer.InvariantCultureIgnoreCase)
                : new HashSet<string>(StringComparer.InvariantCultureIgnoreCase);

            selectedFields.Add(fkProp.Name);

            AddOrUpdateMap(entityMap, relatedType, relatedIds, selectedFields);
        }

        private static void HandleManyToMany(
            AppDbContext dbContext,
            IEnumerable<TEntity> entityList,
            string field,
            string crossTableName,
            Dictionary<Type, (HashSet<TKey>, HashSet<string>)> entityMap,
            IResolverContext context)
        {
            var pkProp = TypeProviders.GetPrimaryKeyProperty<TEntity>(dbContext);

            var entityIds = entityList
                .Select(e => pkProp.GetValue(e))
                .Where(v => v is TKey)
                .Cast<TKey>()
                .ToList();

            var navProperty = typeof(TEntity)
                .GetProperties()
                .FirstOrDefault(p => p.Name.Equals(crossTableName, StringComparison.OrdinalIgnoreCase))
                ?? throw new Exception($"Navigation property '{crossTableName}' not found.");

            var crossEntityType = navProperty.PropertyType.GetGenericArguments().First();

            var crossEntityTypeModel = dbContext.Model.FindEntityType(crossEntityType)
                ?? throw new Exception($"Cross entity '{crossEntityType.Name}' not found in model.");

            var crossKeys = crossEntityTypeModel.FindPrimaryKey()?.Properties.Select(p => p.Name).ToList()
                ?? throw new Exception($"Primary keys not found in '{crossEntityType.Name}'.");

            var targetKey = crossKeys.FirstOrDefault(k => !k.Equals(pkProp.Name, StringComparison.OrdinalIgnoreCase))
                ?? throw new Exception("Target foreign key not found in cross entity.");

            var crossSourceProp = crossEntityType.GetProperty(pkProp.Name)
                ?? throw new Exception($"Source FK '{pkProp.Name}' not found in '{crossEntityType.Name}'.");

            var crossTargetProp = crossEntityType.GetProperty(targetKey)
                ?? throw new Exception($"Target FK '{targetKey}' not found in '{crossEntityType.Name}'.");

            var relatedIds = TypeProviders.GetRelatedEntityIds(
                dbContext,
                crossEntityType,
                crossSourceProp,
                crossTargetProp,
                entityIds.ToHashSet()
            );

            var singularFieldName = PluralWordProvider.ConvertToSingular(field);
            var relatedEntityType = (crossEntityType
                .GetProperties()
                .FirstOrDefault(p => p.Name.Equals(singularFieldName, StringComparison.OrdinalIgnoreCase))
                ?.PropertyType)
                ?? throw new Exception($"Could not resolve related entity type from field '{field}' in cross entity '{crossEntityType.Name}'");

            if (relatedEntityType.IsGenericType &&
                relatedEntityType.GetInterfaces().Any(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>)) &&
                relatedEntityType != typeof(string))
            {
                relatedEntityType = relatedEntityType.GetGenericArguments().FirstOrDefault()
                                    ?? throw new Exception("Could not extract generic argument from related entity type.");
            }

            var selectedFields = GraphQLFieldProvider.GetNestedSelectedFields(context, field);

            AddOrUpdateMap(entityMap, relatedEntityType, relatedIds, selectedFields);
        }

        private static void AddOrUpdateMap(
            Dictionary<Type, (HashSet<TKey>, HashSet<string>)> map,
            Type type,
            IEnumerable<TKey> ids,
            IEnumerable<string> fields)
        {
            if (!map.TryGetValue(type, out var entry))
            {
                entry = ([], []);
                map[type] = entry;
            }

            entry.Item1.UnionWith(ids);
            entry.Item2.UnionWith(fields);
        }
    }

}
