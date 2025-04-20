using FluentValidation;
using HotChocolate.Execution.Configuration;

namespace XenoTerra.WebAPI.GraphQL.Extensions.Builders
{
    public class GraphQLEntityBuilder(IServiceCollection services, IRequestExecutorBuilder graphqlBuilder)
    {
        private readonly IServiceCollection _services = services;
        private readonly IRequestExecutorBuilder _graphqlBuilder = graphqlBuilder;

        public GraphQLEntityBuilder AddType<T>()
            where T : class
        {
            _graphqlBuilder.AddType<T>();
            return this;
        }

        public GraphQLEntityBuilder AddType(Type type)
        {
            _graphqlBuilder.AddType(type);
            return this;
        }

        public GraphQLEntityBuilder AddSubscription<T>()
            where T : class
        {
            _graphqlBuilder.AddSubscriptionType<T>();
            _services.AddScoped<T>();
            return this;
        }

        public GraphQLEntityBuilder AddSubscription(Type subscriptionType)
        {
            _graphqlBuilder.AddSubscriptionType(subscriptionType);
            _services.AddScoped(subscriptionType);
            return this;
        }

        public GraphQLEntityBuilder AddService<TInterface, TImplementation>()
            where TInterface : class
            where TImplementation : class, TInterface
        {
            _services.AddScoped<TInterface, TImplementation>();
            return this;
        }

        public GraphQLEntityBuilder AddService(Type iface, Type impl)
        {
            _services.AddScoped(iface, impl);
            return this;
        }

        public GraphQLEntityBuilder AddService<TImplementation>()
            where TImplementation : class
        {
            _services.AddScoped<TImplementation>();
            return this;
        }

        public GraphQLEntityBuilder AddService(Type serviceType)
        {
            _services.AddScoped(serviceType);
            return this;
        }

        public GraphQLEntityBuilder AddValidator<TValidator>()
            where TValidator : class
        {
            var validatorType = typeof(TValidator);
            var dtoType = validatorType.BaseType?.GetGenericArguments().FirstOrDefault();

            if (dtoType != null)
            {
                var interfaceType = typeof(IValidator<>).MakeGenericType(dtoType);
                _services.AddScoped(interfaceType, validatorType);
            }

            return this;
        }

        public GraphQLEntityBuilder AddValidator(Type validatorType)
        {
            var dtoType = validatorType.BaseType?.GetGenericArguments().FirstOrDefault();

            if (dtoType != null)
            {
                var interfaceType = typeof(IValidator<>).MakeGenericType(dtoType);
                _services.AddScoped(interfaceType, validatorType);
            }

            return this;
        }

        public IServiceCollection Services => _services;
        public IRequestExecutorBuilder GraphQLBuilder => _graphqlBuilder;
    }
}
