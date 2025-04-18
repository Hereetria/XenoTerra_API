using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.DataAccessLayer.Utils
{
    public static class CrossTableNameProvider
    {

        public static string? GetCrossTableName<TEntity>(string targetEntityName)
        {
            targetEntityName = WordInflector.ConvertToSingular(targetEntityName);

            var entityType = typeof(TEntity);

            var collectionProps = entityType
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.PropertyType.IsGenericType &&
                            p.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>))
                .ToList();

            foreach (var prop in collectionProps)
            {
                var potentialJoinEntityType = prop.PropertyType.GetGenericArguments().FirstOrDefault();
                if (potentialJoinEntityType == null)
                    continue;

                var joinProps = potentialJoinEntityType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

                bool hasTargetEntity = joinProps.Any(p =>
                    string.Equals(p.PropertyType.Name, targetEntityName, StringComparison.InvariantCultureIgnoreCase) ||
                    (p.PropertyType.IsGenericType &&
                     p.PropertyType.GetGenericArguments().Any(t =>
                         string.Equals(t.Name, targetEntityName, StringComparison.InvariantCultureIgnoreCase))));

                if (hasTargetEntity)
                {
                    return prop.Name;
                }
            }

            return null;
        }
    }
}
