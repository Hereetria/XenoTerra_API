using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Extensions.Suffixs
{
    public readonly record struct GraphQLServiceSuffix(string Value)
    {
        public static readonly GraphQLServiceSuffix Query = new("Query");
        public static readonly GraphQLServiceSuffix Mutation = new("Mutation");
        public static readonly GraphQLServiceSuffix Subscription = new("Subscription");
        public static readonly GraphQLServiceSuffix DataLoader = new("DataLoader");

        public static readonly IReadOnlyList<GraphQLServiceSuffix> All = SuffixHelper.GetAll<GraphQLServiceSuffix>();

        public override string ToString() => Value;
    }
}
