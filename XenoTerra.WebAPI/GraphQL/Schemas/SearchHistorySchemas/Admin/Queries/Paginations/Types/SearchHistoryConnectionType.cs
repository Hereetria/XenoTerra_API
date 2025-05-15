using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Queries.Paginations.Types
{
    public class SearchHistoryConnectionType : ObjectType<SearchHistoryConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<SearchHistoryConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
