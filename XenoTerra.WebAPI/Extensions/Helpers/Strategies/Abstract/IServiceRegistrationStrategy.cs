using System.Reflection;

namespace XenoTerra.WebAPI.Extensions.Helpers.Strategies.Abstract
{
    public interface IServiceRegistrationStrategy
    {
        void Register(IServiceCollection services, IEnumerable<Type> types);
        bool CanHandle(Type type);
    }
}
