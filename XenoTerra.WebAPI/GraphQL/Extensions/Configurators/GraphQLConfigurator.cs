using System.Reflection;
using XenoTerra.BussinessLogicLayer.Services.Entity.BlockUserService;
using XenoTerra.DataAccessLayer.Repositories.Entity.BlockUserRepository;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Extensions.Builders;
using XenoTerra.WebAPI.GraphQL.Extensions.Registrars;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Queries;

namespace XenoTerra.WebAPI.GraphQL.Extensions.Configurators
{
    public static class GraphQLConfigurator
    {
        public static void ConfigureEntityModules(GraphQLEntityBuilder builder)
        {
            var assemblies = new[]
            {
            typeof(BlockUser).Assembly,
            typeof(ResultBlockUserDto).Assembly,
            typeof(BlockUserReadRepository).Assembly,
            typeof(BlockUserReadService).Assembly,
            typeof(BlockUserQuery).Assembly
        };

            var allEntityNames = typeof(BlockUser).Assembly
                .GetTypes()
                .Where(t =>
                    t.IsClass &&
                    !t.IsAbstract &&
                    t.Namespace is not null)
                .Select(t => t.Name)
                .Distinct()
                .ToList();

            var entityNamespace = typeof(BlockUser).Namespace!;
            var entityTypes = typeof(BlockUser).Assembly
                .GetTypes()
                .Where(t =>
                    t.IsClass &&
                    !t.IsAbstract &&
                    t.Namespace == entityNamespace)
                .ToList();

            foreach (var entityType in entityTypes)
            {
                builder.RegisterEntityArtifacts(assemblies, entityType, allEntityNames);
            }
        }
    }
}
