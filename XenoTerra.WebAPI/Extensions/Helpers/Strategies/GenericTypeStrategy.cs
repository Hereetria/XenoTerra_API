using FluentValidation;
using System.Reflection;
using XenoTerra.WebAPI.Extensions.Helpers.Strategies.Abstract;
using XenoTerra.WebAPI.Extensions.Helpers.Utils;

namespace XenoTerra.WebAPI.Extensions.Helpers.Strategies
{
    public class GenericTypeStrategy : IServiceRegistrationStrategy
    {
        public void Register(IServiceCollection services, IEnumerable<Type> types)
        {
            // FluentValidation destekli: IValidator<T>
            var genericInterfaceDefinitions = new[]
            {
            typeof(IValidator<>)
        };

            foreach (var genericInterface in genericInterfaceDefinitions)
            {
                var validators = types
                    .Where(t => t.IsClass && !t.IsAbstract)
                    .SelectMany(t => t.GetInterfaces()
                        .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == genericInterface)
                        .Select(i => new { ValidatorType = t, InterfaceType = i }))
                    .ToList();

                foreach (var pair in validators)
                {
                    if (!services.Any(s => s.ServiceType == pair.InterfaceType))
                    {
                        services.AddScoped(pair.InterfaceType, pair.ValidatorType);
                    }
                }
            }
        }

        public bool CanHandle(Type type)
        {
            return type.IsClass && !type.IsAbstract &&
                   type.GetInterfaces().Any(i =>
                       i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IValidator<>));
        }
    }

}
