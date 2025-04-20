using System.Reflection;

namespace XenoTerra.WebAPI.Helpers
{
    public static class SuffixHelper
    {
        public static IReadOnlyList<T> GetAll<T>()
            where T : struct
            => [
                .. typeof(T)
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(f => f.FieldType == typeof(T))
                .Select(f => (T)f.GetValue(null)!)
            ];
    }
}
