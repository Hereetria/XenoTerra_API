namespace XenoTerra.WebAPI.Extensions.Helpers.Utils
{
    public static class SafeEndsWithExtension
    {
        public static bool SafeEndsWith(string typeName, string suffix)
        {
            if (!typeName.EndsWith(suffix, StringComparison.OrdinalIgnoreCase)) return false;
            int startIndex = typeName.Length - suffix.Length;
            return startIndex == 0 || char.IsUpper(typeName[startIndex]);
        }
    }
}
