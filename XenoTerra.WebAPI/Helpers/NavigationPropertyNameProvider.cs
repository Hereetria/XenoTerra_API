using System.Reflection;
using XenoTerra.DataAccessLayer.Helpers;

namespace XenoTerra.WebAPI.Helpers
{
    public static class NavigationPropertyNameProvider
    {

        public static string GetNavigationPropertyName(Type entityType, string fieldName)
        {
            var propInfo = entityType.GetProperty(fieldName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
            if (propInfo == null)
                throw new Exception($"Property '{fieldName}' not found on type '{entityType.Name}'.");

            bool isCollection = typeof(IEnumerable<>).IsAssignableFrom(propInfo.PropertyType)
                                && propInfo.PropertyType != typeof(string);

            if (isCollection)
            {
                return WordInflector.ConvertToPlural(fieldName);
            }
            else
            {
                return WordInflector.ConvertToSingular(fieldName);
            }
        }
    }
}
