using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Extensions.Suffixs
{
    public readonly record struct GraphQLTypeSuffix(string Value)
    {
        public static readonly GraphQLTypeSuffix InputType = new("InputType");
        public static readonly GraphQLTypeSuffix PayloadType = new("PayloadType");
        public static readonly GraphQLTypeSuffix FilterType = new("FilterType");
        public static readonly GraphQLTypeSuffix SortType = new("SortType");
        public static readonly GraphQLTypeSuffix ConnectionType = new("ConnectionType");
        public static readonly GraphQLTypeSuffix EdgeType = new("EdgeType");
        public static readonly GraphQLTypeSuffix EventType = new("EventType");
        public static readonly GraphQLTypeSuffix Type = new("Type");

        public static readonly IReadOnlyList<GraphQLTypeSuffix> All = SuffixHelper.GetAll<GraphQLTypeSuffix>();

        public override string ToString() => Value;
    }
}
