using Microsoft.EntityFrameworkCore;
using System.Reflection;
using XenoTerra.DataAccessLayer.Helpers;
using XenoTerra.DataAccessLayer.Persistence;

namespace XenoTerra.WebAPI.Services.Common.EntityAssignment
{
    public class EntityAssignmentService<TEntity, TRelatedEntity, TRelatedKey>
        : IEntityAssignmentService<TEntity, TRelatedEntity, TRelatedKey>
        where TEntity : class
        where TRelatedEntity : class
        where TRelatedKey : notnull
    {
        public List<TEntity> AssignRelatedEntities(
            AppDbContext dbContext,
            List<TEntity> entityList,
            IReadOnlyDictionary<TRelatedKey, TRelatedEntity> relatedEntities)
        {
            var navProperties = EntityAssignmentService<TEntity, TRelatedEntity, TRelatedKey>.GetMatchingNavigationProperties();

            foreach (var navProperty in navProperties)
            {
                var relatedEntityType = EntityAssignmentService<TEntity, TRelatedEntity, TRelatedKey>.GetNavigationEntityType(navProperty);
                if (relatedEntityType == null)
                    continue;

                var crossTableName = CrossTableNameProvider.GetCrossTableName<TEntity>(navProperty.Name);


                if (crossTableName != null)
                {
                    AssignManyToMany(dbContext, entityList, relatedEntities, navProperty, crossTableName);
                }
                else if (TypeProviders.HasForeignKeyTo<TEntity>(dbContext, navProperty.Name))
                {
                    AssignManyToOne(dbContext, entityList, relatedEntities, navProperty);
                }
                else
                {
                    EntityAssignmentService<TEntity, TRelatedEntity, TRelatedKey>.AssignOneToMany(dbContext, entityList, relatedEntities, navProperty);
                }
            }

            return entityList;
        }
        private static void AssignManyToOne(
            AppDbContext dbContext,
            List<TEntity> entityList,
            IReadOnlyDictionary<TRelatedKey, TRelatedEntity> relatedEntities,
            PropertyInfo navProperty)
        {
            foreach (var entity in entityList)
            {
                var fkProperty = TypeProviders.GetForeignKeyProperty<TEntity>(dbContext, navProperty.Name);

                if (fkProperty == null)
                    continue;

                var key = fkProperty.GetValue(entity);
                if (key is TRelatedKey relatedKey && relatedEntities.TryGetValue(relatedKey, out var related))
                {
                    navProperty.SetValue(entity, related);
                }
            }
        }
        private static void AssignOneToMany(
            AppDbContext dbContext,
            List<TEntity> entityList,
            IReadOnlyDictionary<TRelatedKey, TRelatedEntity> relatedEntities,
            PropertyInfo navProperty)
        {
            var entityNavProp = typeof(TEntity)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .FirstOrDefault(p => string.Equals(p.Name, navProperty.Name, StringComparison.OrdinalIgnoreCase));
            if (entityNavProp == null)
                return;

            var propertyType = entityNavProp.PropertyType;
            var relatedEntityType = propertyType != typeof(string) &&
                                    propertyType.IsGenericType &&
                                    propertyType.GetInterfaces().Any(i =>
                                        i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                ? propertyType.GetGenericArguments().FirstOrDefault()
                : propertyType;
            if (relatedEntityType == null)
                return;

            var entityIdProp = TypeProviders.GetPrimaryKeyProperty(dbContext, typeof(TEntity));
            if (entityIdProp == null)
                return;

            var singularNavPropertyName = WordInflector.ConvertToSingular(navProperty.Name);

            var navigationName = typeof(TEntity).Name;

            var fkPropName = TypeProviders.GetForeignKeyProperty<TRelatedEntity>(dbContext, navigationName)?.Name;

            if (fkPropName == null)
                return;

            var fkProperty = typeof(TRelatedEntity).GetProperty(fkPropName, BindingFlags.Public | BindingFlags.Instance);
            if (fkProperty == null)
                return;

            foreach (var entity in entityList)
            {
                var entityId = entityIdProp.GetValue(entity);
                if (entityId == null)
                    continue;

                var matches = relatedEntities.Values
                    .Where(rel => Equals(fkProperty.GetValue(rel), entityId))
                    .ToList();
                if (matches.Count == 0)
                    continue;

                var listType = typeof(List<>).MakeGenericType(relatedEntityType);
                if (Activator.CreateInstance(listType) is not System.Collections.IList list)
                    continue;

                foreach (var item in matches)
                {
                    list.Add(item);
                }

                navProperty.SetValue(entity, list);
            }
        }
        private static void AssignManyToMany(
            AppDbContext dbContext,
            List<TEntity> entityList,
            IReadOnlyDictionary<TRelatedKey, TRelatedEntity> resultsDict,
            PropertyInfo navProperty,
            string crossTableName)
        {
            var entityKeyProperty = dbContext.Model.FindEntityType(typeof(TEntity))!
                .FindPrimaryKey()!
                .Properties[0];
            var entityKeyPropertyName = entityKeyProperty.Name;

            var crossNavProp = typeof(TEntity)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
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
                .FirstOrDefault(k => !k.Name.Equals(entityKeyPropertyName, StringComparison.InvariantCultureIgnoreCase))
                ?.Name
                ?? throw new Exception("Could not determine related entity key property.");

            crossTableName = WordInflector.ConvertToSingular(crossTableName);
            var crossTableType = dbContext.Model.GetEntityTypes()
                .FirstOrDefault(e => e.ClrType.Name.Equals(crossTableName, StringComparison.InvariantCultureIgnoreCase))
                ?.ClrType
                ?? throw new Exception($"Cross table '{crossTableName}' not found.");

            var entityIdToRelatedIds = TypeProviders.GetEntityIdToRelatedIds(
                dbContext,
                crossTableType,
                entityKeyPropertyName,
                relatedEntityKeyPropertyName);

            var relatedKeyProperty = typeof(TRelatedEntity).GetProperty(relatedEntityKeyPropertyName)
                ?? throw new Exception($"Related entity '{typeof(TRelatedEntity).Name}' does not contain '{relatedEntityKeyPropertyName}'");

            var relatedEntityDict = resultsDict.Values
                .ToDictionary(x => relatedKeyProperty.GetValue(x)!, x => x);

            foreach (var entity in entityList)
            {
                var entityId = entityKeyProperty.PropertyInfo?.GetValue(entity);
                if (entityId == null)
                    continue;

                if (!entityIdToRelatedIds.TryGetValue(entityId, out var relatedIdList))
                    continue;

                var navType = navProperty.PropertyType;
                var elementType = navType.IsGenericType
                    ? navType.GetGenericArguments().First()
                    : typeof(object);

                var listType = typeof(List<>).MakeGenericType(elementType);
                var listInstance = Activator.CreateInstance(listType);
                if (listInstance is not System.Collections.IList list)
                    throw new Exception($"Failed to create list of type List<{elementType.Name}>");

                foreach (var relatedId in relatedIdList)
                {
                    if (relatedEntityDict.TryGetValue(relatedId, out var relatedEntity))
                    {
                        list.Add(relatedEntity);
                    }
                }

                navProperty.SetValue(entity, list);
            }
        }


        private static Type? GetNavigationEntityType(PropertyInfo navProperty)
        {
            var propertyType = navProperty.PropertyType;

            if (propertyType == typeof(string))
                return propertyType;

            if (propertyType.IsGenericType &&
                propertyType.GetInterfaces().Any(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>)))
            {
                return propertyType.GetGenericArguments().FirstOrDefault();
            }

            return propertyType;
        }

        private static List<PropertyInfo> GetMatchingNavigationProperties()
        {
            return [.. typeof(TEntity).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p =>
                    p.PropertyType == typeof(TRelatedEntity ) ||
                    (p.PropertyType.IsGenericType &&
                     p.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>) &&
                     p.PropertyType.GetGenericArguments()[0] == typeof(TRelatedEntity)))];
        }

    }

}
