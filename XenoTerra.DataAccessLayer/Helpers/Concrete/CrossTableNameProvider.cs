using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Persistence;

namespace XenoTerra.DataAccessLayer.Helpers.Concrete
{
    public static class CrossTableNameProvider
    {
        public static string? GetCrossTableName<TEntity>(AppDbContext dbContext, string targetEntityName)
        {
            if (string.IsNullOrWhiteSpace(targetEntityName))
                return null;

            var entityType = typeof(TEntity);
            var singularTarget = WordInflector.ConvertToSingular(targetEntityName);

            // 🔹 0. Direct match: Eğer entity içinde targetEntityName birebir bir ICollection navigation varsa onu döndür
            var directMatch = entityType
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .FirstOrDefault(p =>
                    p.PropertyType.IsGenericType &&
                    p.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>) &&
                    string.Equals(p.Name, targetEntityName, StringComparison.OrdinalIgnoreCase));

            if (directMatch != null)
                return null; // Bu doğrudan ilişki, cross table değil

            // 🔹 1. Tüm collection navigation'ları kontrol et
            var collectionProps = entityType
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.PropertyType.IsGenericType &&
                            p.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>))
                .ToList();

            foreach (var prop in collectionProps)
            {
                var joinClrType = prop.PropertyType.GetGenericArguments().FirstOrDefault();
                if (joinClrType == null)
                    continue;

                var joinEntityType = dbContext.Model.FindEntityType(joinClrType);
                if (joinEntityType == null)
                    continue;

                var foreignKeys = joinEntityType.GetForeignKeys().ToList();
                var navigations = joinEntityType.GetNavigations().ToList();
                var primaryKey = joinEntityType.FindPrimaryKey();

                if (foreignKeys.Count != 2 || navigations.Count != 2)
                    continue;

                if (primaryKey == null || primaryKey.Properties.Count != 2)
                    continue;

                var fkProps = foreignKeys.SelectMany(fk => fk.Properties).ToHashSet();
                var pkProps = primaryKey.Properties.ToHashSet();

                if (!fkProps.SetEquals(pkProps))
                    continue;

                var extraProps = joinEntityType.GetProperties()
                    .Where(p => !fkProps.Contains(p))
                    .ToList();

                if (extraProps.Any())
                    continue;

                // 🔹 targetEntity'yi tipiyle eşle (daha güvenli, isim yerine tip kontrolü)
                var hasEntityRef = navigations.Any(n => n.TargetEntityType.ClrType == entityType);
                var hasTargetRef = navigations.Any(n =>
                {
                    var clr = n.TargetEntityType.ClrType;
                    return string.Equals(clr.Name, singularTarget, StringComparison.OrdinalIgnoreCase) ||
                           string.Equals(WordInflector.ConvertToPlural(clr.Name), targetEntityName, StringComparison.OrdinalIgnoreCase);
                });

                if (!hasEntityRef || !hasTargetRef)
                    continue;

                // ✅ Tüm şartlar sağlandıysa cross table budur
                return prop.Name;
            }

            return null;
        }
    }
}
