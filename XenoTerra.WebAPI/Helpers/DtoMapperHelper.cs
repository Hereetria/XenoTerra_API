﻿namespace XenoTerra.WebAPI.Helpers
{
    public static class DtoMapperHelper
    {
        public static TDestination MapInputToDto<TSource, TDestination>(
            TSource source,
            IEnumerable<string>? selectedFields = null)
            where TSource : class
            where TDestination : new()
        {
            TDestination destination = new();

            var sourceProperties = typeof(TSource).GetProperties();
            var destinationProperties = typeof(TDestination).GetProperties();

            var fieldsToMap = selectedFields != null
                ? destinationProperties.Where(p => selectedFields.Contains(p.Name, StringComparer.OrdinalIgnoreCase))
                : destinationProperties;

            foreach (var destProp in destinationProperties)
            {
                var inSelectedFields = selectedFields == null || selectedFields.Contains(destProp.Name, StringComparer.OrdinalIgnoreCase);

                if (!inSelectedFields)
                {
                    if (Nullable.GetUnderlyingType(destProp.PropertyType) != null || !destProp.PropertyType.IsValueType)
                        destProp.SetValue(destination, null);
                    continue;
                }

                var sourceProp = sourceProperties.FirstOrDefault(
                    x => string.Equals(x.Name, destProp.Name, StringComparison.OrdinalIgnoreCase));

                if (sourceProp == null) continue;

                var sourceValue = sourceProp.GetValue(source);

                try
                {
                    object? convertedValue;

                    if (sourceValue is null || (sourceValue is string sv && string.IsNullOrWhiteSpace(sv)))
                    {
                        convertedValue = Nullable.GetUnderlyingType(destProp.PropertyType) != null ? null : null;
                    }
                    else if (destProp.PropertyType == typeof(Guid) || destProp.PropertyType == typeof(Guid?))
                        convertedValue = Guid.Parse(sourceValue.ToString()!);
                    else if (destProp.PropertyType == typeof(DateTime) || destProp.PropertyType == typeof(DateTime?))
                        convertedValue = DateTime.Parse(sourceValue.ToString()!);
                    else if (destProp.PropertyType.IsEnum)
                        convertedValue = Enum.Parse(destProp.PropertyType, sourceValue.ToString()!);
                    else if (destProp.PropertyType == sourceProp.PropertyType)
                        convertedValue = sourceValue;
                    else
                    {
                        throw GraphQLExceptionFactory.Create(
                            $"Cannot map property '{sourceProp.Name}' to '{destProp.Name}'. Type mismatch: {sourceProp.PropertyType.Name} → {destProp.PropertyType.Name}",
                            "DTO_MAPPING_ERROR");
                    }

                    destProp.SetValue(destination, convertedValue);
                }
                catch (Exception ex)
                {
                    throw GraphQLExceptionFactory.Create(
                        $"Failed to convert '{sourceProp.Name}' to '{destProp.PropertyType.Name}': {ex.Message}",
                        "DTO_CONVERSION_ERROR");
                }
            }

            return destination;
        }
    }
}