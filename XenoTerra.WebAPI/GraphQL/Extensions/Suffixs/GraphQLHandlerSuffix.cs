using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Extensions.Suffixs
{
    public readonly record struct GraphQLHandlerSuffix(string Value)
    {
        public static readonly GraphQLHandlerSuffix Subscription = new("Subscription");

        public static readonly IReadOnlyList<GraphQLHandlerSuffix> All = SuffixHelper.GetAll<GraphQLHandlerSuffix>();

        public override string ToString() => Value;
    }
}
