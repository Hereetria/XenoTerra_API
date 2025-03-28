using System.Reflection;
using XenoTerra.WebAPI.Extensions.Enums;
using XenoTerra.WebAPI.Extensions.Helpers.Strategies.Abstract;

namespace XenoTerra.WebAPI.Extensions.Helpers
{
    public static class ServiceRegistrationExtensions
    {
        public static readonly HashSet<string> ValidSuffixes =
            Enum.GetNames(typeof(ServiceSuffix)).ToHashSet(StringComparer.OrdinalIgnoreCase);

        public static void RegisterAllScopedServices(
            this IServiceCollection services,
            IEnumerable<Assembly> assemblies,
            IEnumerable<IServiceRegistrationStrategy> strategies)
        {
            var allTypes = assemblies.SelectMany(a => a.GetTypes()).ToList();

            foreach (var strategy in strategies)
            {
                var matchingTypes = allTypes.Where(strategy.CanHandle).ToList();
                strategy.Register(services, matchingTypes);
            }
        }
    }
}
