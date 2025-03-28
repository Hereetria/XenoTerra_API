using System.Reflection;
using XenoTerra.WebAPI.Extensions.Helpers.Strategies.Abstract;
using XenoTerra.WebAPI.Extensions.Helpers.Utils;

namespace XenoTerra.WebAPI.Extensions.Helpers.Strategies
{
    public class ConcreteTypeStrategy : IServiceRegistrationStrategy
    {
        public void Register(IServiceCollection services, IEnumerable<Type> types)
        {
            var concreteTypes = types
                .Where(t => t.IsClass && !t.IsAbstract &&
                            ServiceRegistrationExtensions.ValidSuffixes.Any(suffix => SafeEndsWithExtension.SafeEndsWith(t.Name, suffix)))
                .ToList();

            foreach (var type in concreteTypes)
            {
                if (!services.Any(s => s.ServiceType == type))
                {
                    services.AddScoped(type);
                }
            }
        }

    public bool CanHandle(Type type)
        {
            return type.IsClass && !type.IsAbstract &&
                   ServiceRegistrationExtensions.ValidSuffixes.Any(suffix => SafeEndsWithExtension.SafeEndsWith(type.Name, suffix));
        }
    }
}