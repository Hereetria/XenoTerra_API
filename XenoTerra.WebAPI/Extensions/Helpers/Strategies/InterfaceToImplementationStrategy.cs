using System.Reflection;
using XenoTerra.WebAPI.Extensions.Helpers.Strategies.Abstract;
using XenoTerra.WebAPI.Extensions.Helpers.Utils;

namespace XenoTerra.WebAPI.Extensions.Helpers.Strategies
{
    public class InterfaceToImplementationStrategy : IServiceRegistrationStrategy
    {
        public void Register(IServiceCollection services, IEnumerable<Type> types)
        {
            var interfaceTypes = types
                .Where(t => t.IsInterface && ServiceRegistrationExtensions.ValidSuffixes.Any(suffix => SafeEndsWithExtension.SafeEndsWith(t.Name, suffix)))
                .ToList();

            foreach (var interfaceType in interfaceTypes)
            {
                var implementation = types.FirstOrDefault(t =>
                    t.IsClass && !t.IsAbstract &&
                    interfaceType.IsAssignableFrom(t) &&
                    string.Equals(t.Name, interfaceType.Name.TrimStart('I'), StringComparison.OrdinalIgnoreCase)
                );

                if (implementation != null && !services.Any(s => s.ServiceType == interfaceType))
                {
                    services.AddScoped(interfaceType, implementation);
                }
            }
        }

        public bool CanHandle(Type type)
        {
            return type.IsInterface &&
                   ServiceRegistrationExtensions.ValidSuffixes.Any(suffix => SafeEndsWithExtension.SafeEndsWith(type.Name, suffix));
        }

    }
}
