using Microsoft.EntityFrameworkCore;
using System.Reflection;
using XenoTerra.DataAccessLayer.Helpers.Concrete;
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.EntityLayer.Entities;

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
            var navProperties = GetMatchingNavigationProperties();

            foreach (var navProperty in navProperties)
            {
                var relatedEntityType = EntityAssignmentService<TEntity, TRelatedEntity, TRelatedKey>.GetNavigationEntityType(navProperty);
                if (relatedEntityType == null)
                    continue;

                var crossTableName = CrossTableNameProvider.GetCrossTableName<TEntity>(dbContext, navProperty.Name);

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
                var fkProperty = TypeProviders.GetForeignKeyPropertyFromRelated<TEntity>(dbContext, navProperty.Name);

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
            var isCollection = propertyType != typeof(string) &&
                               propertyType.IsGenericType &&
                               propertyType.GetInterfaces().Any(i =>
                                   i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>));

            var relatedEntityType = isCollection
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

                if (isCollection)
                {
                    // Assign as List<T>
                    var listType = typeof(List<>).MakeGenericType(relatedEntityType);
                    if (Activator.CreateInstance(listType) is not System.Collections.IList list)
                        continue;

                    foreach (var item in matches)
                        list.Add(item);

                    navProperty.SetValue(entity, list);
                }
                else
                {
                    // Assign single item
                    navProperty.SetValue(entity, matches.First());
                }
            }
        }

        private static void AssignManyToMany(
            AppDbContext dbContext,
            List<TEntity> entityList,
            IReadOnlyDictionary<TRelatedKey, TRelatedEntity> resultsDict,
            PropertyInfo navProperty,
            string crossTableName)
        {
            var entityType = typeof(TEntity);
            var relatedEntityType = typeof(TRelatedEntity);

            var entityTypeModel = dbContext.Model.FindEntityType(entityType)
                ?? throw new Exception($"Entity type '{entityType.Name}' not found in model.");

            var entityKeyProperty = entityTypeModel.FindPrimaryKey()?.Properties.FirstOrDefault()
                ?? throw new Exception($"Primary key not found for entity '{entityType.Name}'.");

            var entityKeyPropertyName = entityKeyProperty.Name;
            var entityKeyClrProperty = entityKeyProperty.PropertyInfo
                ?? throw new Exception($"PropertyInfo for key '{entityKeyPropertyName}' is null.");

            var crossNavProp = entityType
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .FirstOrDefault(p => string.Equals(p.Name, crossTableName, StringComparison.OrdinalIgnoreCase))
                ?? throw new Exception($"Navigation '{crossTableName}' not found on entity '{entityType.Name}'.");

            var crossEntityType = crossNavProp.PropertyType.GetGenericArguments().FirstOrDefault()
                ?? throw new Exception($"'{crossTableName}' is not a valid generic navigation.");

            var crossEntityTypeModel = dbContext.Model.FindEntityType(crossEntityType)
                ?? throw new Exception($"Entity type '{crossEntityType.Name}' not found in model.");

            var crossEntityKeys = crossEntityTypeModel.FindPrimaryKey()?.Properties;
            if (crossEntityKeys == null || crossEntityKeys.Count != 2)
                throw new Exception($"Cross entity '{crossEntityType.Name}' must have exactly 2 primary keys.");

            var relatedEntityKeyPropertyName = crossEntityKeys
                .FirstOrDefault(k => !k.Name.Equals(entityKeyPropertyName, StringComparison.OrdinalIgnoreCase))
                ?.Name
                ?? throw new Exception("Could not determine related entity key property.");

            var entityIdToRelatedIds = TypeProviders.GetEntityIdToRelatedIds(
                dbContext,
                crossEntityType,
                entityKeyPropertyName,
                relatedEntityKeyPropertyName);

            var relatedEntityKeyProp = relatedEntityType.GetProperty(relatedEntityKeyPropertyName)
                ?? throw new Exception($"'{relatedEntityType.Name}' does not contain property '{relatedEntityKeyPropertyName}'.");

            var relatedEntityDict = resultsDict.Values
                .ToDictionary(x => relatedEntityKeyProp.GetValue(x)!, x => x);

            var crossEntityToEntityFkProp = crossEntityType.GetProperty(entityKeyPropertyName)
                ?? throw new Exception($"'{entityKeyPropertyName}' not found on '{crossEntityType.Name}'.");

            var crossEntityToRelatedFkProp = crossEntityType.GetProperty(relatedEntityKeyPropertyName)
                ?? throw new Exception($"'{relatedEntityKeyPropertyName}' not found on '{crossEntityType.Name}'.");

            var crossEntityNavToRelated = crossEntityType.GetProperty(navProperty.Name)
                ?? throw new Exception($"Navigation '{navProperty.Name}' not found on '{crossEntityType.Name}'.");

            foreach (var entity in entityList)
            {
                var entityId = entityKeyClrProperty.GetValue(entity);
                if (entityId == null || !entityIdToRelatedIds.TryGetValue(entityId, out var relatedIdList))
                    continue;

                var listType = typeof(List<>).MakeGenericType(crossEntityType);
                var listInstance = Activator.CreateInstance(listType);
                if (listInstance is not System.Collections.IList list)
                    throw new Exception($"Failed to create list of type List<{crossEntityType.Name}>");

                foreach (var relatedId in relatedIdList)
                {
                    if (!relatedEntityDict.TryGetValue(relatedId, out var relatedEntity))
                        continue;

                    var crossInstance = Activator.CreateInstance(crossEntityType)!;

                    crossEntityToEntityFkProp.SetValue(crossInstance, entityId);
                    crossEntityToRelatedFkProp.SetValue(crossInstance, relatedId);
                    crossEntityNavToRelated.SetValue(crossInstance, relatedEntity);

                    list.Add(crossInstance);
                }

                crossNavProp.SetValue(entity, list);
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
            var entityType = typeof(TEntity);
            var relatedType = typeof(TRelatedEntity);

            var directMatches = entityType
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p =>
                    p.PropertyType == relatedType ||
                    (p.PropertyType.IsGenericType &&
                     p.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>) &&
                     p.PropertyType.GetGenericArguments()[0] == relatedType))
                .ToList();

            if (directMatches.Count > 0)
                return directMatches;

            var crossProps = entityType
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p =>
                    p.PropertyType.IsGenericType &&
                    p.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>))
                .ToList();

            foreach (var crossProp in crossProps)
            {
                var joinType = crossProp.PropertyType.GetGenericArguments().FirstOrDefault();
                if (joinType == null)
                    continue;

                var joinProps = joinType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

                var relatedNavInJoin = joinProps.FirstOrDefault(p =>
                    p.PropertyType == relatedType ||
                    (p.PropertyType.IsGenericType &&
                     p.PropertyType.GetGenericArguments().Any(t => t == relatedType)));

                if (relatedNavInJoin == null)
                    continue;

                return [relatedNavInJoin];
            }

            return [];
        }
    }

}
