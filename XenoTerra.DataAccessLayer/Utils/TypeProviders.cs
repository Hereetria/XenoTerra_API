using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.DataAccessLayer.Utils
{
    public static class TypeProviders
    {
        public static PropertyInfo GetPrimaryKeyProperty(AppDbContext context, Type entityType)
        {
            var method = typeof(TypeProviders)
                .GetMethod(nameof(GetPrimaryKeyProperty), new[] { typeof(AppDbContext) })!
                .MakeGenericMethod(entityType);

            return (PropertyInfo)method.Invoke(null, new object[] { context })!;
        }

        public static PropertyInfo GetPrimaryKeyProperty<TEntity>(AppDbContext context)
        {
            var entityType = typeof(TEntity);
            var model = context.Model.FindEntityType(entityType);
            if (model == null)
                throw new InvalidOperationException($"EntityType {entityType.Name} için model bulunamadı.");

            var primaryKey = model.FindPrimaryKey();
            if (primaryKey == null)
                throw new InvalidOperationException($"Entity {entityType.Name} için Primary Key bulunamadı.");

            var pkPropertyName = primaryKey.Properties.FirstOrDefault()?.Name;
            if (pkPropertyName == null)
                throw new InvalidOperationException($"Entity {entityType.Name} için geçerli bir Primary Key property bulunamadı.");

            var propertyInfo = entityType.GetProperty(pkPropertyName, BindingFlags.Public | BindingFlags.Instance);
            return propertyInfo ?? throw new InvalidOperationException($"Property {pkPropertyName} bulunamadı.");
        }

        public static PropertyInfo GetForeignKeyProperty<TEntity>(AppDbContext dbContext, string navigationPropertyName, string? crossTableName = null)
            where TEntity : class
        {
            navigationPropertyName = crossTableName != null ? PluralWordProvider.ConvertToSingular(navigationPropertyName) : navigationPropertyName;

            var entityType = crossTableName == null
                ? dbContext.Model.FindEntityType(typeof(TEntity))
                : dbContext.Model.GetEntityTypes()
                    .FirstOrDefault(e => e.ClrType.Name.Equals(crossTableName, StringComparison.OrdinalIgnoreCase));

            if (entityType == null)
                throw new Exception($"Entity type '{(crossTableName ?? typeof(TEntity).Name)}' not found in DbContext.");

            var navigation = entityType.GetNavigations()
                .FirstOrDefault(n => n.Name.Equals(navigationPropertyName, StringComparison.OrdinalIgnoreCase))
                ?? throw new Exception($"Navigation property '{navigationPropertyName}' not found in entity '{entityType.ClrType.Name}'.");

            var foreignKey = navigation.ForeignKey.Properties.FirstOrDefault()
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

            var primaryKeyName = primaryKey.Properties.FirstOrDefault()?.Name
                ?? throw new InvalidOperationException($"Primary key name not found for '{typeof(TRelatedEntity).Name}'.");

            var foreignKeyName = foreignKeyProperty.Name;

            var entityPrimaryKeySet = new HashSet<TKey>(entityPrimaryKeys);

            var result = dbContext.Set<TRelatedEntity>()
                .Where(e => entityPrimaryKeySet.Contains(EF.Property<TKey>(e, foreignKeyName)))
                .Select(e => EF.Property<TKey>(e, primaryKeyName))
                .ToList();

            return result;
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
            return type.IsPrimitive || type.IsValueType || type == typeof(string) || type == typeof(DateTime) || type == typeof(Guid);
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
