using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Queries.Paginations.Types
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
