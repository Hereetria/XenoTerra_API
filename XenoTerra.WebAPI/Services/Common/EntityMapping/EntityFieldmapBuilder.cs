using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.WebAPI.Utils;
using GreenDonut;

namespace XenoTerra.WebAPI.Services.Common.EntityMapping
{
    public class EntityFieldMapBuilder<TEntity, TDtoResult, TKey> : IEntityFieldMapBuilder<TEntity, TDtoResult, TKey>
        where TEntity : class
        where TDtoResult : class
        where TKey : notnull
    {
        private Dictionary<Type, List<TKey>> _entityKeyMap = new();
        private HashSet<TKey> _idsCache = new();
        public Dictionary<Type, (HashSet<TKey>, HashSet<string>)> Build(
            IEnumerable<TDtoResult> dtoList,
            IResolverContext context)
        {
            var dbContext = context.Service<AppDbContext>();
            var entityType = dbContext.Model.FindEntityType(typeof(TEntity))
                ?? throw new Exception($"Entity '{typeof(TEntity).Name}' not found in DbContext.");
            var relationalFields = GraphQLFieldProvider.GetRelationalFields(context);
            var entityMap = new Dictionary<Type, (HashSet<TKey>, HashSet<string>)>();

            foreach (var field in relationalFields)
            {
                var crossTableName = CrossTableNameProvider.GetCrossTableName<TEntity>(dbContext, field);

                if (crossTableName != null)
                {
                    HandleManyToMany(dbContext, dtoList, entityType, field, crossTableName, entityMap, context);
                }
                else if (TypeProviders.HasForeignKeyTo<TEntity>(dbContext, field))
                {
                    HandleManyToOne(dbContext, dtoList, field, entityMap, context);
                }
                else
                {
                    HandleOneToMany(dbContext, dtoList, field, entityMap, context);
                }
            }
            _idsCache.Clear();
            _entityKeyMap.Clear();

            return entityMap;
        }

        private void HandleManyToOne(
            AppDbContext dbContext,
            IEnumerable<TDtoResult> dtoList,
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

            var dtoKeyProp = typeof(TDtoResult).GetProperty(foreignKeyProperty.Name)
                ?? throw new Exception($"DTO does not contain property '{foreignKeyProperty.Name}'");

                var ids = dtoList
                    .Select(e => dtoKeyProp.GetValue(e))
                    .Where(x => x is TKey)
                    .Cast<TKey>()
                    .ToHashSet();

            var selectedFields = GraphQLFieldProvider.GetNestedSelectedFields(context, field);

            AddOrUpdateMap(entityMap, entityProperty.PropertyType, ids, selectedFields);
        }

        private void HandleOneToMany(
            AppDbContext dbContext,
            IEnumerable<TDtoResult> dtoList,
            string field,
            Dictionary<Type, (HashSet<TKey>, HashSet<string>)> entityMap,
            IResolverContext context)
        {
            var entityType = dbContext.Model.FindEntityType(typeof(TEntity))!;
            var pkProp = TypeProviders.GetPrimaryKeyProperty<TEntity>(dbContext);

            var dtoPrimaryKeyProp = typeof(TDtoResult).GetProperty(pkProp.Name)
                ?? throw new Exception($"DTO does not contain key property '{pkProp.Name}'");

                var primaryKeys = dtoList
                    .Select(e => dtoPrimaryKeyProp.GetValue(e))
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

            var fkProp = genericFkMethod.Invoke(null, new object[] { dbContext, singularField, null }) as PropertyInfo
                ?? throw new InvalidOperationException($"Foreign key property not found on related entity '{relatedType.Name}'.");

            var method = typeof(TypeProviders)
                .GetMethod(nameof(TypeProviders.GetRelatedPrimaryKeysByForeignKeyMatch))!
                .MakeGenericMethod(relatedType, typeof(TKey));

            if (!_entityKeyMap.TryGetValue(relatedType, out var relatedIds))
            {
                var result = method.Invoke(
                    null,
                    new object[] { dbContext, fkProp, primaryKeys.ToList() }
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

        private void HandleManyToMany(
            AppDbContext dbContext,
            IEnumerable<TDtoResult> dtoList,
            IEntityType entityType,
            string field,
            string crossTableName,
            Dictionary<Type, (HashSet<TKey>, HashSet<string>)> entityMap,
            IResolverContext context)
        {
            var pkProp = TypeProviders.GetPrimaryKeyProperty<TEntity>(dbContext);
            var dtoKeyProp = typeof(TDtoResult).GetProperty(pkProp.Name)
                ?? throw new Exception($"DTO does not contain key property '{pkProp.Name}'");

            var entityIds = dtoList
                .Select(d => dtoKeyProp.GetValue(d))
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
                ?? throw new Exception($"Primary keys not found in '{crossEntityType.Name}'");

            var targetKey = crossKeys.FirstOrDefault(k => !k.Equals(pkProp.Name, StringComparison.OrdinalIgnoreCase))
                ?? throw new Exception("Target foreign key not found in cross entity.");

            var setMethod = typeof(DbContext).GetMethod(nameof(DbContext.Set), Type.EmptyTypes)!.MakeGenericMethod(crossEntityType);
            var dbSet = (IQueryable)setMethod.Invoke(dbContext, null)!;

            var data = dbSet.Cast<object>().ToList();

            var crossTargetProp = crossEntityType.GetProperty(targetKey)!;
            var crossSourceProp = crossEntityType.GetProperty(pkProp.Name)!;

            var relatedIds = data
                .Where(x => entityIds.Contains((TKey)crossSourceProp.GetValue(x)!))
                .Select(x => (TKey)crossTargetProp.GetValue(x)!)
                .ToHashSet();

            // 2. field parametresi, crossEntityType içinde yer alıyor
            var singularFieldName = PluralWordProvider.ConvertToSingular(field);
            var relatedEntityType = crossEntityType
                .GetProperties()
                .FirstOrDefault(p => p.Name.Equals(singularFieldName, StringComparison.OrdinalIgnoreCase))
                ?.PropertyType;

            if (relatedEntityType == null)
                throw new Exception($"Could not resolve related entity type from field '{field}' in cross entity '{crossEntityType.Name}'");

            // 3. Eğer ICollection<T> ise T'yi al
            if (relatedEntityType.IsGenericType &&
                relatedEntityType.GetInterfaces().Any(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>)) &&
                relatedEntityType != typeof(string))
            {
                relatedEntityType = relatedEntityType.GetGenericArguments().FirstOrDefault()
                                    ?? throw new Exception("Could not extract generic argument from related entity type.");
            }

            var selectedFields = GraphQLFieldProvider.GetNestedSelectedFields(context, field);

            AddOrUpdateMap(entityMap, relatedEntityType!, relatedIds, selectedFields);
        }

        private void AddOrUpdateMap(
            Dictionary<Type, (HashSet<TKey>, HashSet<string>)> map,
            Type type,
            IEnumerable<TKey> ids,
            IEnumerable<string> fields)
        {
            if (!map.TryGetValue(type, out var entry))
            {
                entry = (new HashSet<TKey>(), new HashSet<string>());
                map[type] = entry;
            }

            entry.Item1.UnionWith(ids);
            entry.Item2.UnionWith(fields);
        }
    }

}
