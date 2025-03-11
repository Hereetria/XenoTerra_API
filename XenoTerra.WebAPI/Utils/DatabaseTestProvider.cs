using Microsoft.EntityFrameworkCore;
using System.Text;

namespace XenoTerra.WebAPI.Utils
{
    public static class DatabaseTestProvider
    {
        public static Type GetPropertyTypeFromDbContext<TEntity>(DbContext dbContext, string selectedField)
            where TEntity : class
        {
            var entityType = dbContext.Model.FindEntityType(typeof(TEntity));
            if (entityType == null)
            {
                throw new InvalidOperationException($"Entity metadata for {typeof(TEntity).Name} not found.");
            }

            string normalizedSelectedField = selectedField.Normalize(NormalizationForm.FormC).ToLowerInvariant();

            var property = entityType.GetProperties()
                .FirstOrDefault(p => p.Name.Normalize(NormalizationForm.FormC).ToLowerInvariant() == normalizedSelectedField);

            if (property == null)
            {
                throw new InvalidOperationException($"Property '{selectedField}' not found in entity {typeof(TEntity).Name}.");
            }

            return property.ClrType;
        }

        public static Type GetFieldTypeFromDbContext<TEntity>(DbContext dbContext, string fieldName)
            where TEntity : class
        {
            var entityType = dbContext.Model.FindEntityType(typeof(TEntity));
            if (entityType == null)
            {
                throw new InvalidOperationException($"Entity metadata for {typeof(TEntity).Name} not found.");
            }

            // Küçük/büyük harf duyarsız şekilde alanı bul
            var property = entityType.GetProperties()
                .FirstOrDefault(p => p.Name.ToLowerInvariant() == fieldName.ToLowerInvariant());

            if (property == null)
            {
                throw new InvalidOperationException($"Property '{fieldName}' not found in entity {typeof(TEntity).Name}.");
            }

            return property.ClrType;
        }


        public static string GetPrimaryKeyNameFromDbContext<TEntity>(DbContext dbContext)
            where TEntity : class
        {
            var entityType = dbContext.Model.FindEntityType(typeof(TEntity));
            if (entityType == null)
            {
                throw new InvalidOperationException($"Entity metadata for {typeof(TEntity).Name} not found.");
            }

            var primaryKey = entityType.FindPrimaryKey();
            if (primaryKey == null || primaryKey.Properties.Count == 0)
            {
                throw new InvalidOperationException($"Primary key for {typeof(TEntity).Name} not found.");
            }

            return primaryKey.Properties.First().Name;
        }

    }
}
