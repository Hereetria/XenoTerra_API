using Microsoft.EntityFrameworkCore;
using System.Reflection;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Services.Common.EntityAssignment
{
    public class EntityAssignmentService<TEntity, TDtoResult, TRelatedDtoResult, TRelatedKey>
        : IEntityAssignmentService<TEntity, TDtoResult, TRelatedDtoResult, TRelatedKey>
        where TEntity : class
        where TDtoResult : class
        where TRelatedDtoResult : class
        where TRelatedKey : notnull
    {
        public List<TDtoResult> AssignRelatedEntities(
            AppDbContext dbContext,
            List<TDtoResult> dtoList,
            IReadOnlyDictionary<TRelatedKey, TRelatedDtoResult> relatedEntities)
        {
            var navProperties = GetMatchingNavigationProperties();

            foreach (var navProperty in navProperties)
            {
                var relatedEntityType = GetNavigationEntityType(navProperty);
                if (relatedEntityType == null)
                    continue;

                var crossTableName = CrossTableNameProvider.GetCrossTableName<TEntity>(dbContext, navProperty.Name);


                if (crossTableName != null)
                {
                    AssignManyToMany(dbContext, dtoList, relatedEntities, navProperty, crossTableName);
                }
                else if (TypeProviders.HasForeignKeyTo<TEntity>(dbContext, navProperty.Name))
                {
                    AssignManyToOne(dtoList, relatedEntities, navProperty);
                }
                else
                {
                    AssignOneToMany(dbContext, dtoList, relatedEntities, navProperty);
                }
            }

            return dtoList;
        }

        private void AssignManyToOne(
            List<TDtoResult> dtoList,
            IReadOnlyDictionary<TRelatedKey, TRelatedDtoResult> relatedEntities,
            PropertyInfo navProperty)
        {
            var fkProperty = typeof(TDtoResult).GetProperty(navProperty.Name + "Id", BindingFlags.Public | BindingFlags.Instance);

            if (fkProperty == null || fkProperty.PropertyType != typeof(TRelatedKey))
                return;

            foreach (var dto in dtoList)
            {
                var key = fkProperty.GetValue(dto);
                if (key is TRelatedKey relatedKey && relatedEntities.TryGetValue(relatedKey, out var related))
                {
                    navProperty.SetValue(dto, related);
                }
            }
        }

        private void AssignOneToMany(
            AppDbContext dbContext,
            List<TDtoResult> dtoList,
            IReadOnlyDictionary<TRelatedKey, TRelatedDtoResult> relatedEntities,
            PropertyInfo navProperty)
        {
            // navProperty.Name ile TEntity içindeki karşılık gelen property'yi bul
            var entityNavProp = typeof(TEntity)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .FirstOrDefault(p => string.Equals(p.Name, navProperty.Name, StringComparison.OrdinalIgnoreCase));

            if (entityNavProp == null)
                return;

            // Eğer ICollection<T> gibi bir şeyse, T'yi çıkar
            var propertyType = entityNavProp.PropertyType;
            var relatedEntityType =
                propertyType != typeof(string) &&
                propertyType.IsGenericType &&
                propertyType.GetInterfaces().Any(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                ? propertyType.GetGenericArguments().FirstOrDefault()
                : propertyType;

            if (relatedEntityType == null)
                return;

            var method = GetType()
                .GetMethod(nameof(AssignOneToManyInternal), BindingFlags.NonPublic | BindingFlags.Instance)
                ?.MakeGenericMethod(relatedEntityType);

            method?.Invoke(this, new object[] { dbContext, dtoList, relatedEntities, navProperty });
        }






        private void AssignOneToManyInternal<TRelatedEntity>(
            AppDbContext dbContext,
            List<TDtoResult> dtoList,
            IReadOnlyDictionary<TRelatedKey, TRelatedDtoResult> relatedEntities,
            PropertyInfo navProperty)
            where TRelatedEntity : class
        {
            var entityIdProp = TypeProviders.GetPrimaryKeyProperty(dbContext, typeof(TEntity));
            if (entityIdProp == null)
                return;

            var dtoIdProp = typeof(TDtoResult)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .FirstOrDefault(p => string.Equals(p.Name, entityIdProp.Name, StringComparison.OrdinalIgnoreCase))
                ?? throw new ArgumentNullException($"{entityIdProp.Name} not found in {typeof(TDtoResult)}");


            var singularNavPropertyName = PluralWordProvider.ConvertToSingular(navProperty.Name);

            var fkPropName = TypeProviders.GetForeignKeyProperty<TRelatedEntity>(dbContext, singularNavPropertyName)?.Name;
            if (fkPropName == null)
                return;

            var fkProperty = typeof(TRelatedDtoResult).GetProperty(fkPropName, BindingFlags.Public | BindingFlags.Instance);
            if (fkProperty == null)
                return;

            foreach (var dto in dtoList)
            {
                var dtoId = dtoIdProp.GetValue(dto);
                if (dtoId == null)
                    continue;

                var matches = relatedEntities.Values
                    .Where(rel => Equals(fkProperty.GetValue(rel), dtoId))
                    .ToList();

                if (!matches.Any())
                    continue;

                var list = new List<TRelatedDtoResult>();
                foreach (var item in matches)
                {
                    list.Add(item);
                }

                navProperty.SetValue(dto, list);
            }
        }


        private void AssignManyToMany(
            AppDbContext dbContext,
            List<TDtoResult> resultDtoList,
            IReadOnlyDictionary<TRelatedKey, TRelatedDtoResult> resultsDict,
            PropertyInfo navProperty,
            string crossTableName)
        {
            var entityKeyProperty = dbContext.Model.FindEntityType(typeof(TEntity))!
                .FindPrimaryKey()!
                .Properties.First();
            var entityKeyPropertyName = entityKeyProperty.Name;

            var dtoKeyProperty = typeof(TDtoResult).GetProperty(entityKeyPropertyName)
                ?? throw new Exception($"DTO '{typeof(TDtoResult).Name}' does not contain '{entityKeyPropertyName}'");

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
                .FirstOrDefault(k => !k.Name.Equals(entityKeyProperty.Name, StringComparison.InvariantCultureIgnoreCase))
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

            var relatedEntityDict = resultsDict.Values
                .ToDictionary(x => relatedKeyProperty.GetValue(x)!, x => x);

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

                navProperty.SetValue(resultDto, list);
            }
        }



        private IList<object> CreateTypedList(Type navPropertyType, IEnumerable<object> items)
        {
            var elementType = navPropertyType.IsGenericType
                ? navPropertyType.GetGenericArguments().First()
                : typeof(object);

            var listType = typeof(List<>).MakeGenericType(elementType);
            var list = (IList<object>)Activator.CreateInstance(listType)!;

            foreach (var item in items)
            {
                list.Add(item);
            }

            return list;
        }

        private Type? GetNavigationEntityType(PropertyInfo navProperty)
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

        private PropertyInfo NormalizeCollectionNavigation(PropertyInfo navProperty)
        {
            var navType = navProperty.PropertyType;

            if (navType != typeof(string) &&
                navType.IsGenericType &&
                navType.GetInterfaces().Any(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>)))
            {
                var innerType = navType.GetGenericArguments().FirstOrDefault();
                if (innerType == null)
                    return navProperty;

                var matchingProp = typeof(TEntity).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .FirstOrDefault(p =>
                        string.Equals(p.PropertyType.Name, innerType.Name, StringComparison.OrdinalIgnoreCase));

                return matchingProp ?? navProperty;
            }

            return navProperty;
        }

        private List<PropertyInfo> GetMatchingNavigationProperties()
        {
            return typeof(TDtoResult).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p =>
                    p.PropertyType == typeof(TRelatedDtoResult) ||
                    (p.PropertyType.IsGenericType &&
                     p.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>) &&
                     p.PropertyType.GetGenericArguments()[0] == typeof(TRelatedDtoResult)))
                .ToList();
        }

    }

}
