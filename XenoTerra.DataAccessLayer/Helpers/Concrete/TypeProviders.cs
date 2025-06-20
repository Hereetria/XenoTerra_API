using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Persistence;

namespace XenoTerra.DataAccessLayer.Helpers.Concrete
{
    public static class TypeProviders
    {
        public static PropertyInfo GetPrimaryKeyProperty(AppDbContext context, Type entityType)
        {
            var method = typeof(TypeProviders)
                .GetMethod(nameof(GetPrimaryKeyProperty), [typeof(AppDbContext)])!
                .MakeGenericMethod(entityType);

            return (PropertyInfo)method.Invoke(null, [context])!;
        }

        public static PropertyInfo GetPrimaryKeyProperty<TEntity>(AppDbContext context)
        {
            var entityType = typeof(TEntity);
            var model = context.Model.FindEntityType(entityType)
                ?? throw new InvalidOperationException($"Model could not be found for entity type '{entityType.Name}'.");

            var primaryKey = model.FindPrimaryKey()
                ?? throw new InvalidOperationException($"Primary key could not be found for entity '{entityType.Name}'.");

            var pkPropertyName = primaryKey.Properties[0].Name
                ?? throw new InvalidOperationException($"A valid primary key property could not be resolved for entity '{entityType.Name}'.");

            var propertyInfo = entityType.GetProperty(pkPropertyName, BindingFlags.Public | BindingFlags.Instance)
                ?? throw new InvalidOperationException($"Property '{pkPropertyName}' could not be found on entity '{entityType.Name}'.");

            return propertyInfo;
        }

        public static PropertyInfo GetForeignKeyProperty<TEntity>(
            AppDbContext dbContext,
            string navigationPropertyName,
            string? crossTableName = null)
            where TEntity : class
        {
            var model = dbContext.Model;

            var entityType = string.IsNullOrWhiteSpace(crossTableName)
                ? model.FindEntityType(typeof(TEntity))
                : model.GetEntityTypes()
                    .FirstOrDefault(e =>
                        string.Equals(e.ClrType.Name, crossTableName, StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(e.ClrType.Name, WordInflector.ConvertToSingular(crossTableName), StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(e.ClrType.Name, WordInflector.ConvertToPlural(crossTableName), StringComparison.OrdinalIgnoreCase));

            if (entityType == null)
                throw new Exception($"Entity type '{crossTableName ?? typeof(TEntity).Name}' not found in model.");

            var navNameCandidates = new[]
            {
        navigationPropertyName,
        WordInflector.ConvertToSingular(navigationPropertyName),
        WordInflector.ConvertToPlural(navigationPropertyName)
    }
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToList();

            // Try to resolve FK via direct navigation
            var navigation = entityType.GetNavigations()
                .FirstOrDefault(n =>
                    navNameCandidates.Any(candidate =>
                        candidate.Equals(n.Name, StringComparison.OrdinalIgnoreCase)));

            // Fallback: Try to resolve via property name if navigation name fails
            if (navigation == null)
            {
                var fallbackProperty = typeof(TEntity).GetProperties()
                    .FirstOrDefault(p =>
                        p.PropertyType.Name.Equals(navigationPropertyName, StringComparison.OrdinalIgnoreCase) ||
                        p.PropertyType.IsGenericType && p.PropertyType.GetGenericArguments()
                            .Any(t => t.Name.Equals(navigationPropertyName, StringComparison.OrdinalIgnoreCase)));

                if (fallbackProperty != null)
                {
                    navigation = entityType.GetNavigations()
                        .FirstOrDefault(n => n.Name.Equals(fallbackProperty.Name, StringComparison.OrdinalIgnoreCase));
                }
            }

            if (navigation != null)
            {
                var foreignKey = navigation.ForeignKey;

                if (foreignKey.Properties.Count != 1)
                    throw new NotSupportedException("Only single-column foreign keys are supported.");

                if (foreignKey.DeclaringEntityType.ClrType == typeof(TEntity))
                {
                    var fkPropertyName = foreignKey.Properties[0].Name;

                    var fkProperty = typeof(TEntity)
                        .GetProperty(fkPropertyName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase)
                        ?? throw new Exception($"Foreign key property '{fkPropertyName}' not found on '{typeof(TEntity).Name}'.");

                    return fkProperty;
                }
                else
                {
                    var principalEntityType = foreignKey.PrincipalEntityType;
                    var primaryKey = principalEntityType.FindPrimaryKey();

                    if (primaryKey == null || primaryKey.Properties.Count != 1)
                        throw new NotSupportedException($"Primary key for '{principalEntityType.ClrType.Name}' could not be resolved.");

                    var pkPropertyName = primaryKey.Properties[0].Name;

                    var principalProperty = principalEntityType.ClrType
                        .GetProperty(pkPropertyName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase)
                        ?? throw new Exception($"Primary key property '{pkPropertyName}' not found on '{principalEntityType.ClrType.Name}'.");

                    return principalProperty;
                }
            }

            // Inverse navigation fallback
            var candidateEntity = model.GetEntityTypes()
                .FirstOrDefault(e =>
                    navNameCandidates.Any(candidate =>
                        candidate.Equals(e.ClrType.Name, StringComparison.OrdinalIgnoreCase)));

            if (candidateEntity == null)
            {
                var available = string.Join(", ", model.GetEntityTypes().Select(e => e.ClrType.Name));
                throw new Exception($"Entity matching navigation '{navigationPropertyName}' not found. Candidates: {string.Join(", ", navNameCandidates)}. Available: {available}");
            }

            var inverseNavigation = candidateEntity.GetNavigations()
                .FirstOrDefault(n => n.TargetEntityType.ClrType == typeof(TEntity));

            if (inverseNavigation == null)
                throw new Exception($"No navigation from '{candidateEntity.ClrType.Name}' to '{typeof(TEntity).Name}' found.");

            var foreignKeyInverse = inverseNavigation.ForeignKey;

            if (foreignKeyInverse.Properties.Count != 1)
                throw new NotSupportedException("Only single-column foreign keys are supported.");

            var inverseFkName = foreignKeyInverse.Properties[0].Name;

            var inverseFkProp = foreignKeyInverse.DeclaringEntityType.ClrType
                .GetProperty(inverseFkName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase)
                ?? throw new Exception($"Foreign key property '{inverseFkName}' not found on '{foreignKeyInverse.DeclaringEntityType.ClrType.Name}'.");

            return inverseFkProp;
        }


        public static PropertyInfo GetForeignKeyPropertyFromRelated<TEntity>(
    AppDbContext dbContext,
    string relatedNavigationPropertyName)
    where TEntity : class
        {
            var model = dbContext.Model;

            var entityType = model.FindEntityType(typeof(TEntity))
                ?? throw new Exception($"Entity type '{typeof(TEntity).Name}' not found in model.");

            var relatedNavigation = entityType
                .GetNavigations()
                .FirstOrDefault(n => string.Equals(n.Name, relatedNavigationPropertyName, StringComparison.OrdinalIgnoreCase))
                ?? throw new Exception($"Navigation '{relatedNavigationPropertyName}' not found on entity '{typeof(TEntity).Name}'.");

            var foreignKey = relatedNavigation.ForeignKey;

            if (foreignKey.Properties.Count != 1)
                throw new NotSupportedException("Only single-column foreign keys are supported.");

            var fkPropertyName = foreignKey.Properties[0].Name;

            var fkProperty = foreignKey.DeclaringEntityType.ClrType
                .GetProperty(fkPropertyName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase)
                ?? throw new Exception($"Foreign key property '{fkPropertyName}' not found on '{foreignKey.DeclaringEntityType.ClrType.Name}'.");

            return fkProperty;
        }


        public static PropertyInfo GetRelatedEntityKeyProperty<TEntity>(
    AppDbContext dbContext,
    string navigationPropertyName,
    string? crossTableName = null)
    where TEntity : class
        {
            var model = dbContext.Model;

            var entityType = crossTableName == null
                ? model.FindEntityType(typeof(TEntity))
                : model.GetEntityTypes()
                    .FirstOrDefault(e => e.ClrType.Name.Equals(crossTableName, StringComparison.OrdinalIgnoreCase));

            if (entityType == null)
                throw new Exception($"Entity type '{crossTableName ?? typeof(TEntity).Name}' not found in model.");

            var navNameCandidates = new[]
            {
        navigationPropertyName,
        WordInflector.ConvertToSingular(navigationPropertyName),
        WordInflector.ConvertToPlural(navigationPropertyName)
    }
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToList();

            var navigation = entityType.GetNavigations()
                .FirstOrDefault(n =>
                    navNameCandidates.Any(candidate =>
                        candidate.Equals(n.Name, StringComparison.OrdinalIgnoreCase)));

            // Fallback: tip eşleşmesine göre navigation kontrolü
            if (navigation == null)
            {
                var fallbackProperty = typeof(TEntity).GetProperties()
                    .FirstOrDefault(p =>
                        p.PropertyType.Name.Equals(navigationPropertyName, StringComparison.OrdinalIgnoreCase) ||
                        p.PropertyType.IsGenericType && p.PropertyType.GetGenericArguments()
                            .Any(t => t.Name.Equals(navigationPropertyName, StringComparison.OrdinalIgnoreCase))
                    );

                if (fallbackProperty != null)
                {
                    navigation = entityType.GetNavigations()
                        .FirstOrDefault(n => n.Name.Equals(fallbackProperty.Name, StringComparison.OrdinalIgnoreCase));
                }
            }

            if (navigation == null)
            {
                throw new Exception($"Navigation property '{navigationPropertyName}' not found in entity '{typeof(TEntity).Name}'.");
            }

            var foreignKey = navigation.ForeignKey;

            var principalEntityType = foreignKey.PrincipalEntityType;
            var primaryKey = principalEntityType.FindPrimaryKey();

            if (primaryKey == null || primaryKey.Properties.Count != 1)
                throw new NotSupportedException($"Primary key for '{principalEntityType.ClrType.Name}' could not be resolved.");

            var pkPropertyName = primaryKey.Properties[0].Name;

            var principalProperty = principalEntityType.ClrType
                .GetProperty(pkPropertyName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase)
                ?? throw new Exception($"Primary key property '{pkPropertyName}' not found on '{principalEntityType.ClrType.Name}'.");

            return principalProperty;
        }

        public static string GetForeignKeyPropertyName(
            DbContext dbContext,
            Type principalType,
            Type relatedType)
        {
            var principalEntity = dbContext.Model.FindEntityType(principalType)
                ?? throw new InvalidOperationException($"Entity type '{principalType.Name}' not found in DbContext.");

            var relatedEntity = dbContext.Model.FindEntityType(relatedType)
                ?? throw new InvalidOperationException($"Entity type '{relatedType.Name}' not found in DbContext.");

            var matchingNavigation = relatedEntity
                .GetNavigations()
                .FirstOrDefault(n => n.TargetEntityType.ClrType == principalType);

            if (matchingNavigation == null)
                throw new InvalidOperationException(
                    $"No navigation found on '{relatedType.Name}' pointing to '{principalType.Name}'.");

            var foreignKey = matchingNavigation.ForeignKey;

            if (foreignKey.Properties.Count != 1)
                throw new NotSupportedException("Only single-column foreign keys are supported.");

            return foreignKey.Properties[0].Name;
        }


        public static string GetForeignKeyPropertyName<TEntity, TRelatedEntity>(DbContext dbContext)
            where TEntity : class
            where TRelatedEntity : class
        {
            var principalEntity = dbContext.Model.FindEntityType(typeof(TEntity))
                ?? throw new InvalidOperationException($"Entity type '{typeof(TEntity).Name}' not found in DbContext.");

            var relatedEntity = dbContext.Model.FindEntityType(typeof(TRelatedEntity))
                ?? throw new InvalidOperationException($"Entity type '{typeof(TRelatedEntity).Name}' not found in DbContext.");

            // RelatedEntity içindeki navigasyonlar taranır: örn. Post.User → User.Id
            var matchingNavigation = relatedEntity
                .GetNavigations()
                .FirstOrDefault(n => n.TargetEntityType.ClrType == typeof(TEntity));

            if (matchingNavigation == null)
                throw new InvalidOperationException(
                    $"No navigation found on '{typeof(TRelatedEntity).Name}' pointing to '{typeof(TEntity).Name}'.");

            var foreignKey = matchingNavigation.ForeignKey;

            if (foreignKey.Properties.Count != 1)
                throw new NotSupportedException("Only single-column foreign keys are supported.");

            return foreignKey.Properties[0].Name;
        }

        public static string GetRelatedForeignKeyPropertyName<TEntity, TRelatedEntity>(DbContext dbContext)
            where TEntity : class
            where TRelatedEntity : class
        {
            var entityType = dbContext.Model.FindEntityType(typeof(TEntity))
                ?? throw new InvalidOperationException($"Entity type '{typeof(TEntity).Name}' not found in DbContext.");

            var navigation = entityType
                .GetNavigations()
                .FirstOrDefault(n => n.TargetEntityType.ClrType == typeof(TRelatedEntity));

            if (navigation == null)
                throw new InvalidOperationException(
                    $"No navigation from '{typeof(TEntity).Name}' to '{typeof(TRelatedEntity).Name}' found.");

            var foreignKey = navigation.ForeignKey;

            if (foreignKey.Properties.Count != 1)
                throw new NotSupportedException("Only single-column foreign keys are supported.");

            return foreignKey.Properties[0].Name;
        }


        public static List<TKey> GetRelatedPrimaryKeysByForeignKeyMatch<TPrincipal, TRelated, TKey>(
            DbContext dbContext,
            string navigationPropertyName,
            List<TKey> principalKeys
        )
            where TPrincipal : class
            where TRelated : class
        {
            var principalEntity = dbContext.Model.FindEntityType(typeof(TPrincipal))
                ?? throw new InvalidOperationException($"Entity type '{typeof(TPrincipal).Name}' not found.");

            var navigation = principalEntity
                .GetNavigations()
                .FirstOrDefault(n => n.Name.Equals(navigationPropertyName, StringComparison.OrdinalIgnoreCase))
                ?? throw new InvalidOperationException($"Navigation '{navigationPropertyName}' not found on '{typeof(TPrincipal).Name}'.");

            var foreignKey = navigation.ForeignKey;

            if (foreignKey.Properties.Count != 1 || foreignKey.PrincipalKey.Properties.Count != 1)
                throw new NotSupportedException("Only single-column foreign key relationships are supported.");

            var fkName = foreignKey.Properties[0].Name;

            var relatedEntityType = dbContext.Model.FindEntityType(typeof(TRelated))
                ?? throw new InvalidOperationException($"Entity type '{typeof(TRelated).Name}' not found.");

            var relatedPk = relatedEntityType.FindPrimaryKey()?.Properties.FirstOrDefault()
                ?? throw new InvalidOperationException($"Primary key not found on related entity '{typeof(TRelated).Name}'.");

            var relatedPkName = relatedPk.Name;

            return dbContext.Set<TRelated>()
                .Where(e => principalKeys.Contains(EF.Property<TKey>(e, fkName)))
                .Select(e => EF.Property<TKey>(e, relatedPkName))
                .ToList();
        }









        public static HashSet<TKey> GetRelatedEntityIds<TKey>(
            DbContext dbContext,
            Type crossEntityType,
            PropertyInfo sourceKeyProp,
            PropertyInfo targetKeyProp,
            HashSet<TKey> entityIds
        )
        {
            var setMethod = typeof(DbContext).GetMethod(nameof(DbContext.Set), Type.EmptyTypes)!
                .MakeGenericMethod(crossEntityType);

            var dbSet = (IQueryable)setMethod.Invoke(dbContext, null)!;

            var parameter = Expression.Parameter(crossEntityType, "x");
            var sourceProperty = Expression.Property(parameter, sourceKeyProp.Name);
            var containsMethod = typeof(HashSet<TKey>).GetMethod("Contains", [typeof(TKey)])!;
            var entityIdsConst = Expression.Constant(entityIds);
            var containsCall = Expression.Call(entityIdsConst, containsMethod, sourceProperty);
            var lambda = Expression.Lambda(containsCall, parameter);

            var whereMethod = typeof(Queryable).GetMethods()
                .First(m => m.Name == "Where" && m.GetParameters().Length == 2)
                .MakeGenericMethod(crossEntityType);

            var filteredQuery = (IQueryable)whereMethod.Invoke(null, [dbSet, lambda])!;

            var selectorParam = Expression.Parameter(crossEntityType, "x");
            var targetPropAccess = Expression.Property(selectorParam, targetKeyProp.Name);
            var selectLambda = Expression.Lambda(targetPropAccess, selectorParam);

            var selectMethod = typeof(Queryable).GetMethods()
                .First(m => m.Name == "Select" && m.GetParameters().Length == 2)
                .MakeGenericMethod(crossEntityType, typeof(TKey));

            var selectedQuery = (IQueryable<TKey>)selectMethod.Invoke(null, [filteredQuery, selectLambda])!;

            return [.. selectedQuery];
        }

        public static Dictionary<object, List<object>> GetEntityIdToRelatedIds(
            DbContext dbContext,
            Type crossTableType,
            string entityKeyPropertyName,
            string relatedEntityKeyPropertyName)
        {
            var setMethod = typeof(DbContext).GetMethod(nameof(DbContext.Set), Type.EmptyTypes)!
                .MakeGenericMethod(crossTableType);

            var dbSet = (IQueryable)setMethod.Invoke(dbContext, null)!;

            var parameter = Expression.Parameter(crossTableType, "x");
            var entityIdProp = Expression.Property(parameter, entityKeyPropertyName);
            var relatedIdProp = Expression.Property(parameter, relatedEntityKeyPropertyName);

            var anonymousType = typeof(ValueTuple<object, object>);
            var newExpr = Expression.New(
                anonymousType.GetConstructor([typeof(object), typeof(object)])!,
                Expression.Convert(entityIdProp, typeof(object)),
                Expression.Convert(relatedIdProp, typeof(object)));

            var lambda = Expression.Lambda(newExpr, parameter);

            var selectMethod = typeof(Queryable).GetMethods()
                .First(m => m.Name == "Select" && m.GetParameters().Length == 2)
                .MakeGenericMethod(crossTableType, anonymousType);

            var selected = (IQueryable<ValueTuple<object, object>>)selectMethod.Invoke(null, [dbSet, lambda])!;

            return selected
                .ToList()
                .GroupBy(t => t.Item1)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(t => t.Item2).ToList()
                );
        }

        public static bool HasForeignKeyTo<TEntity>(AppDbContext dbContext, string targetEntityPropertyName)
        {
            var entityType = dbContext.Model.FindEntityType(typeof(TEntity))
                ?? throw new InvalidOperationException($"Entity '{typeof(TEntity).Name}' could not be found in DbContext.");

            var targetProperty = typeof(TEntity)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .FirstOrDefault(p => p.Name.Equals(targetEntityPropertyName, StringComparison.InvariantCultureIgnoreCase))
                ?? throw new ArgumentException($"Property '{targetEntityPropertyName}' does not exist on entity '{typeof(TEntity).Name}'.");

            var targetPropertyType = targetProperty.PropertyType;
            var foreignKeys = entityType.GetForeignKeys();

            return foreignKeys.Any(fk => fk.PrincipalEntityType.ClrType == targetPropertyType);
        }

        public static bool IsPrimitiveOrValueType(this Type type)
        {
            type = Nullable.GetUnderlyingType(type) ?? type;

            return type.IsPrimitive
                || type.IsEnum
                || type == typeof(string)
                || type == typeof(decimal)
                || type == typeof(DateTime)
                || type == typeof(Guid)
                || type == typeof(DateTimeOffset)
                || type == typeof(TimeSpan);
        }

        public static Type? GetEntityType<TEntity>(string field)
        {
            return typeof(TEntity)
                .GetProperties()
                .FirstOrDefault(p => p.Name.Equals(field, StringComparison.OrdinalIgnoreCase))
                ?.PropertyType;
        }
    }

}
