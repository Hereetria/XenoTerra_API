using System.Runtime.CompilerServices;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Extensions.Suffixs;

namespace XenoTerra.WebAPI.GraphQL.Extensions.Filters
{
    public static class GraphQLArtifactFilter
    {
        public static readonly IReadOnlyList<string> ForbiddenSuffixes =
        [
            "Dto",
            "Input",
            "Payload",
            "Connection",
            "Edge",
            "Event"
        ];

        public static bool IsExcluded(Type type)
        {
            if (!type.IsClass || type.IsAbstract || type.Namespace is null)
                return true;

            if (type.IsDefined(typeof(CompilerGeneratedAttribute), false))
                return true;

            foreach (var suffix in ForbiddenSuffixes)
            {
                if (type.Name.EndsWith(suffix, StringComparison.Ordinal))
                    return true;
            }

            return false;
        }

        public static bool IsMatchingForEntity(string typeName, string entityName, IReadOnlyCollection<string> allEntityNames)
        {
            var isShadowedByOtherEntity =
                allEntityNames.Any(other =>
                    other != entityName &&
                    other.Contains(entityName, StringComparison.Ordinal));

            if (!isShadowedByOtherEntity)
            {
                return typeName.Contains(entityName, StringComparison.Ordinal);
            }

            var shadowingNames = allEntityNames
                .Where(other =>
                    other != entityName &&
                    other.Contains(entityName, StringComparison.Ordinal))
                .ToList();

            var matchesAnotherLongerEntity =
                shadowingNames.Any(longer => typeName.Contains(longer, StringComparison.Ordinal));

            return typeName.Contains(entityName, StringComparison.Ordinal) && !matchesAnotherLongerEntity;
        }
    }
}
