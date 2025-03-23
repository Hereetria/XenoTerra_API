using System.Reflection;
using XenoTerra.WebAPI.Extensions.Enums;

namespace XenoTerra.WebAPI.Extensions.Helpers
{
    public static class ServiceRegistrationExtensions
    {
        public static readonly HashSet<string> ValidSuffixes =
            Enum.GetNames(typeof(ServiceSuffix)).ToHashSet(StringComparer.OrdinalIgnoreCase);

        public static void RegisterAllScopedServices(this IServiceCollection services, IEnumerable<Assembly> assemblies)
        {
            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes();

                var interfaceTypes = types
                    .Where(t => t.IsInterface && ValidSuffixes.Any(suffix => SafeEndsWith(t.Name, suffix)))
                    .ToList();

                foreach (var interfaceType in interfaceTypes)
                {
                    var implementation = types.FirstOrDefault(t =>
                        t.IsClass && !t.IsAbstract &&
                        interfaceType.IsAssignableFrom(t) &&
                        ValidSuffixes.Any(suffix => SafeEndsWith(t.Name, suffix.Replace("I", "")))
                    );

                    if (implementation != null && !services.Any(s => s.ServiceType == interfaceType))
                    {
                        services.AddScoped(interfaceType, implementation);
                    }
                }

                var concreteTypes = types
                    .Where(t => t.IsClass && !t.IsAbstract &&
                                ValidSuffixes.Any(suffix => SafeEndsWith(t.Name, suffix)))
                    .ToList();

                foreach (var type in concreteTypes)
                {
                    if (!services.Any(s => s.ServiceType == type))
                    {
                        services.AddScoped(type);
                    }
                }
            }
        }

        private static bool SafeEndsWith(string typeName, string suffix)
        {
            if (!typeName.EndsWith(suffix, StringComparison.OrdinalIgnoreCase)) return false;

            int startIndex = typeName.Length - suffix.Length;

            return startIndex == 0 || char.IsUpper(typeName[startIndex]);
        }


    }
}
