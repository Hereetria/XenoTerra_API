using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;

namespace XenoTerra.DataAccessLayer.Utils
{
    public static class TypeProviders
    {
        public static PropertyInfo GetPrimaryKeyProperty(AppDbContext context, Type entityType)
        {
            // EntityType üzerinden EF'nin metadata modelini al
            var model = context.Model.FindEntityType(entityType);
            if (model == null)
            {
                throw new InvalidOperationException($"EntityType {entityType.Name} için model bulunamadı.");
            }

            // Primary key'i al
            var primaryKey = model.FindPrimaryKey();
            if (primaryKey == null)
            {
                throw new InvalidOperationException($"Entity {entityType.Name} için Primary Key bulunamadı.");
            }

            // İlk primary key property'sinin adını al (Çoğu durumda tek bir PK olur)
            var pkPropertyName = primaryKey.Properties.FirstOrDefault()?.Name;
            if (pkPropertyName == null)
            {
                throw new InvalidOperationException($"Entity {entityType.Name} için geçerli bir Primary Key property bulunamadı.");
            }

            // Reflection ile ilgili property'yi Type üzerinden al
            var propertyInfo = entityType.GetProperty(pkPropertyName, BindingFlags.Public | BindingFlags.Instance);

            return propertyInfo ?? throw new InvalidOperationException($"Property {pkPropertyName} bulunamadı.");
        }

        public static PropertyInfo GetPrimaryKeyProperty<TEntity>(AppDbContext context)
        {
            var entityType = typeof(TEntity);
            var model = context.Model.FindEntityType(entityType);
            if (model == null)
            {
                throw new InvalidOperationException($"EntityType {entityType.Name} için model bulunamadı.");
            }

            var primaryKey = model.FindPrimaryKey();
            if (primaryKey == null)
            {
                throw new InvalidOperationException($"Entity {entityType.Name} için Primary Key bulunamadı.");
            }

            var pkPropertyName = primaryKey.Properties.FirstOrDefault()?.Name;
            if (pkPropertyName == null)
            {
                throw new InvalidOperationException($"Entity {entityType.Name} için geçerli bir Primary Key property bulunamadı.");
            }

            var propertyInfo = entityType.GetProperty(pkPropertyName, BindingFlags.Public | BindingFlags.Instance);

            return propertyInfo ?? throw new InvalidOperationException($"Property {pkPropertyName} bulunamadı.");
        }

        public static PropertyInfo GetForeignKeyProperty<TEntity>(AppDbContext dbContext, string navigationPropertyName)
            where TEntity : class
        {
            var entityType = dbContext.Model.FindEntityType(typeof(TEntity))
                ?? throw new Exception($"Entity type '{typeof(TEntity).Name}' not found in DbContext.");

            // **TEntity içindeki Navigation Property'yi bul**
            var navigation = entityType.GetNavigations()
                .FirstOrDefault(n => n.Name.Equals(navigationPropertyName, StringComparison.OrdinalIgnoreCase))
                ?? throw new Exception($"Navigation property '{navigationPropertyName}' not found in entity '{typeof(TEntity).Name}'.");

            // **Foreign Key property'yi bul (EF Core metadatası üzerinden)**
            var foreignKey = navigation.ForeignKey.Properties.FirstOrDefault()
                ?? throw new Exception($"Foreign key not found for navigation '{navigationPropertyName}' in entity '{typeof(TEntity).Name}'.");

            // **TEntity içindeki karşılık gelen foreign key property'sini bul**
            var foreignKeyProperty = typeof(TEntity).GetProperties()
                .FirstOrDefault(p => p.Name.Equals(foreignKey.Name, StringComparison.OrdinalIgnoreCase))
                ?? throw new Exception($"Foreign key '{foreignKey.Name}' not found in entity '{typeof(TEntity).Name}'.");

            return foreignKeyProperty;
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
