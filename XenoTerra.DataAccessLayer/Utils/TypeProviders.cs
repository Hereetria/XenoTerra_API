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
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.DataAccessLayer.Utils
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
                ?? throw new InvalidOperationException($"EntityType {entityType.Name} için model bulunamadı.");

            var primaryKey = model.FindPrimaryKey()
                ?? throw new InvalidOperationException($"Entity {entityType.Name} için Primary Key bulunamadı.");

            string pkPropertyName = (primaryKey.Properties[0].Name)
                ?? throw new InvalidOperationException($"Entity {entityType.Name} için geçerli bir Primary Key property bulunamadı.");

            var propertyInfo = entityType.GetProperty(pkPropertyName, BindingFlags.Public | BindingFlags.Instance);
            return propertyInfo ?? throw new InvalidOperationException($"Property {pkPropertyName} bulunamadı.");
        }

        public static PropertyInfo GetForeignKeyProperty<TEntity>(AppDbContext dbContext, string navigationPropertyName, string? crossTableName = null)
            where TEntity : class
        {
            navigationPropertyName = crossTableName != null ? PluralWordProvider.ConvertToSingular(navigationPropertyName) : navigationPropertyName;

            var entityType = (crossTableName == null
                ? dbContext.Model.FindEntityType(typeof(TEntity))
                : dbContext.Model.GetEntityTypes()
                    .FirstOrDefault(e => e.ClrType.Name.Equals(crossTableName, StringComparison.OrdinalIgnoreCase))) ?? throw new Exception($"Entity type '{(crossTableName ?? typeof(TEntity).Name)}' not found in DbContext.");
            
            var navigation = entityType.GetNavigations()
                .FirstOrDefault(n => n.Name.Equals(navigationPropertyName, StringComparison.OrdinalIgnoreCase))
                ?? throw new Exception($"Navigation property '{navigationPropertyName}' not found in entity '{entityType.ClrType.Name}'.");

            IProperty foreignKey = navigation.ForeignKey.Properties[0]
                ?? throw new Exception($"Foreign key not found for navigation '{navigationPropertyName}' in entity '{entityType.ClrType.Name}'.");


            var foreignKeyProperty = entityType.ClrType.GetProperties()
                .FirstOrDefault(p => p.Name.Equals(foreignKey.Name, StringComparison.OrdinalIgnoreCase))
                ?? throw new Exception($"Foreign key '{foreignKey.Name}' not found in entity '{entityType.ClrType.Name}'.");

            return foreignKeyProperty;
        }

        public static List<TKey> GetRelatedPrimaryKeysByForeignKeyMatch<TRelatedEntity, TKey>(
            DbContext dbContext,
            PropertyInfo foreignKeyProperty,
            List<TKey> entityPrimaryKeys
        ) where TRelatedEntity : class
        {
            var entityType = dbContext.Model.FindEntityType(typeof(TRelatedEntity))
                ?? throw new InvalidOperationException($"Entity type '{typeof(TRelatedEntity).Name}' not found in DbContext.");

            var primaryKey = entityType.FindPrimaryKey()
                ?? throw new InvalidOperationException($"Primary key not found for '{typeof(TRelatedEntity).Name}'.");

            var primaryKeyName = primaryKey.Properties[0].Name
                ?? throw new InvalidOperationException($"Primary key name not found for '{typeof(TRelatedEntity).Name}'.");

            var foreignKeyName = foreignKeyProperty.Name;

            var entityPrimaryKeySet = new HashSet<TKey>(entityPrimaryKeys);

            var result = dbContext.Set<TRelatedEntity>()
                .Where(e => entityPrimaryKeySet.Contains(EF.Property<TKey>(e, foreignKeyName)))
                .Select(e => EF.Property<TKey>(e, primaryKeyName))
                .ToList();

            return result;
        }

        public static HashSet<TKey> GetRelatedEntityIds<TKey>(DbContext dbContext, Type crossEntityType, PropertyInfo sourceKeyProp, PropertyInfo targetKeyProp, HashSet<TKey> entityIds)
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

            var whereMethod = typeof(Queryable)
                .GetMethods()
                .First(m => m.Name == "Where" && m.GetParameters().Length == 2)
                .MakeGenericMethod(crossEntityType);

            var filteredQuery = (IQueryable)whereMethod.Invoke(null, [dbSet, lambda])!;

            var selectorParam = Expression.Parameter(crossEntityType, "x");
            var targetPropAccess = Expression.Property(selectorParam, targetKeyProp.Name);
            var selectLambda = Expression.Lambda(targetPropAccess, selectorParam);

            var selectMethod = typeof(Queryable)
                .GetMethods()
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
                ?? throw new InvalidOperationException($"Entity '{typeof(TEntity).Name}' not found in DbContext.");

            var targetProperty = typeof(TEntity)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .FirstOrDefault(p => string.Equals(p.Name, targetEntityPropertyName, StringComparison.InvariantCultureIgnoreCase))
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
