using HotChocolate.Execution.Configuration;
using HotChocolate.Execution.Options;
using System.Reflection;
using XenoTerra.WebAPI.Extensions.Enums;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace XenoTerra.WebAPI.Extensions.Helpers
{
    public static class GraphQLSchemaExtensions
    {
        public static IServiceCollection AddAllDataLoaders(this IServiceCollection services, Assembly assembly)
        {
            var loaderTypes = assembly.GetTypes()
                .Where(t =>
                    t is { IsClass: true, IsAbstract: false } &&
                    (t.BaseType?.Name.Contains("DataLoader") == true ||
                     t.Name.EndsWith("DataLoader", StringComparison.OrdinalIgnoreCase)))
                .ToList();

            foreach (var loaderType in loaderTypes)
            {
                if (!services.Any(s => s.ServiceType == loaderType))
                {
                    services.AddScoped(loaderType);
                }
            }

            return services;
        }

        public static IServiceCollection AddAllObjectTypes(this IServiceCollection services, Assembly assembly)
        {
            var baseTypeNames = Enum.GetNames(typeof(GraphQLBaseType)).ToHashSet(StringComparer.OrdinalIgnoreCase);

            var gqlTypes = assembly.GetTypes()
                .Where(t => t is { IsClass: true, IsAbstract: false } &&
                            t.BaseType != null &&
                            baseTypeNames.Any(name =>
                                t.BaseType.Name.StartsWith(name, StringComparison.OrdinalIgnoreCase)))
                .ToList();

            services.AddGraphQLServer()
                .ModifyRequestOptions(opt => { })
                .ConfigureSchema(builder =>
                {
                    foreach (var gqlType in gqlTypes)
                    {
                        builder.AddType(gqlType);
                    }
                });

            return services;
        }
    }
}
