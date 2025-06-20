using System.Reflection;
using System.Runtime.CompilerServices;
using XenoTerra.BussinessLogicLayer.Services.Entity.StoryLikeServices;
using XenoTerra.WebAPI.GraphQL.Extensions.Builders;
using XenoTerra.WebAPI.GraphQL.Extensions.Filters;
using XenoTerra.WebAPI.GraphQL.Extensions.Suffixs;

namespace XenoTerra.WebAPI.GraphQL.Extensions.Registrars
{
    public static class GraphQLEntityAutoRegistrar
    {
        public static void RegisterEntityArtifacts(
            this GraphQLEntityBuilder builder,
            IEnumerable<Assembly> assemblies,
            Type entityType,
            IReadOnlyCollection<string> allEntityNames)
        {
            var entityNamespace = entityType.Namespace
                ?? throw new InvalidOperationException("Entity type does not have a namespace.");

            var entityName = entityType.Name;

            var allTypes = assemblies
                .SelectMany(a => a.GetTypes())
                .Where(t =>
                    !GraphQLArtifactFilter.IsExcluded(t) &&
                    GraphQLArtifactFilter.IsMatchingForEntity(t.Name, entityName, allEntityNames))
                .ToList();

            foreach (var type in allTypes)
            {
                var name = type.Name;

                if (name.EndsWith("Validator", StringComparison.Ordinal))
                {
                    builder.AddValidator(type);
                    continue;
                }

                // 1. Interface suffix kontrolü (örnek: BlockUserAdminMutationService → IBlockUserAdminMutationService)
                var matchedInterfaceSuffix = GraphQLServiceInterfaceSuffix.All
                    .FirstOrDefault(suffix => name.EndsWith(suffix.Value, StringComparison.Ordinal));

                if (!matchedInterfaceSuffix.Equals(default))
                {
                    var iface = type.GetInterfaces()
                        .FirstOrDefault(i =>
                            i.Name == $"I{type.Name}" ||
                            i.Name == $"I{type.Name.Replace(matchedInterfaceSuffix.Value, "")}{matchedInterfaceSuffix.Value}")
                        ?? throw new InvalidOperationException(
                            $"Expected interface for {type.Name} not found. Please create I{type.Name} or I{type.Name.Replace(matchedInterfaceSuffix.Value, "")}{matchedInterfaceSuffix.Value}");

                    builder.AddService(iface, type);
                    continue;
                }

                // 2. Handler types (role-aware)
                if (GraphQLHandlerSuffix.All.Any(suffix => name.EndsWith(suffix.Value, StringComparison.Ordinal)))
                {
                    builder.AddType(type);
                    builder.AddService(type);
                    continue;
                }

                // 3. Service types (role-aware, AdminMutation / SelfMutation / Mutation)
                if (GraphQLServiceSuffix.All.Any(suffix => name.EndsWith(suffix.Value, StringComparison.Ordinal)))
                {
                    builder.AddService(type);
                    continue;
                }

                // 4. GraphQL Type classes (InputType, PayloadType vs.) (role-aware)
                if (GraphQLTypeSuffix.All.Any(suffix => name.EndsWith(suffix.Value, StringComparison.Ordinal)))
                {
                    builder.AddType(type);
                    continue;
                }
            }
        }
    }
}
