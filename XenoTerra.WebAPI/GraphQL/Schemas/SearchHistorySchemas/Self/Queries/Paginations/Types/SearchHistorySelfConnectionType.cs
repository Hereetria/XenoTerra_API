using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Self.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Self.Queries.Paginations.Types
{
    public class SearchHistorySelfConnectionType : ObjectType<SearchHistorySelfConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<SearchHistorySelfConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
