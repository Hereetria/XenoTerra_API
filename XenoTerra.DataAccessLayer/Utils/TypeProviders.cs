using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Contexts;

namespace XenoTerra.DataAccessLayer.Utils
{
    public static class TypeProviders
    {
        public static PropertyInfo GetPrimaryKeyProperty(DbContext context, Type entityType)
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
