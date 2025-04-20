using System.Reflection;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Extensions.Suffixs
{
    public readonly record struct GraphQLServiceInterfaceSuffix(string Value)
    {
        public static readonly GraphQLServiceInterfaceSuffix ReadService = new("ReadService");
        public static readonly GraphQLServiceInterfaceSuffix WriteService = new("WriteService");
        public static readonly GraphQLServiceInterfaceSuffix ReadRepository = new("ReadRepository");
        public static readonly GraphQLServiceInterfaceSuffix WriteRepository = new("WriteRepository");
        public static readonly GraphQLServiceInterfaceSuffix QueryService = new("QueryService");
        public static readonly GraphQLServiceInterfaceSuffix MutationService = new("MutationService");
        public static readonly GraphQLServiceInterfaceSuffix Resolver = new("Resolver");

        public static readonly IReadOnlyList<GraphQLServiceInterfaceSuffix> All = SuffixHelper.GetAll<GraphQLServiceInterfaceSuffix>();

        public override string ToString() => Value;
    }
}
