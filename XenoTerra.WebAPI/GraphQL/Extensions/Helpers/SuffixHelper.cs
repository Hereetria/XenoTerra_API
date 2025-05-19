using System.Reflection;

namespace XenoTerra.WebAPI.GraphQL.Extensions.Helpers
{
    public static class SuffixHelper
    {
        private static readonly string[] Roles = ["Admin", "Self"];

        public static IReadOnlyList<T> GetAll<T>() where T : struct
        {
            return [.. typeof(T)
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(f => f.FieldType == typeof(T))
                .Select(f => (T)f.GetValue(null)!)];
        }

        public static IReadOnlyList<T> ExpandWithRoles<T>(IEnumerable<T> baseSuffixes) where T : struct
        {
            var suffixList = new List<T>();
            var valueProperty = typeof(T).GetProperty("Value");

            foreach (var suffix in baseSuffixes)
            {
                suffixList.Add(suffix);

                if (valueProperty?.GetValue(suffix) is string baseValue &&
                    baseValue != "DataLoader")
                {
                    foreach (var role in Roles)
                    {
                        var roleValue = $"{role}{baseValue}";
                        var newInstance = (T)Activator.CreateInstance(typeof(T), roleValue)!;
                        suffixList.Add(newInstance);
                    }
                }
            }

            return suffixList;
        }
    }

}
