using System.Reflection;
using XenoTerra.BussinessLogicLayer.Services.Entity.BlockUserServices.Read;
using XenoTerra.DataAccessLayer.Repositories.Entity.BlockUserRepositories;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Auth;
using XenoTerra.WebAPI.GraphQL.Extensions.Builders;
using XenoTerra.WebAPI.GraphQL.Extensions.Registrars;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Queries;

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
            typeof(BlockUserAdminQuery).Assembly
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

            allEntityNames.Add(nameof(AuthMutation).Replace("Mutation", ""));

            var entityNamespace = typeof(BlockUser).Namespace;
            var entityTypes = typeof(BlockUser).Assembly
                .GetTypes()
                .Where(t =>
                    t.IsClass &&
                    !t.IsAbstract &&
                    t.Namespace == entityNamespace)
                .ToList();

            entityTypes.Add(typeof(AuthMutation));

            foreach (var entityType in entityTypes)
            {
                builder.RegisterEntityArtifacts(assemblies, entityType, allEntityNames);
            }
        }
    }
}
