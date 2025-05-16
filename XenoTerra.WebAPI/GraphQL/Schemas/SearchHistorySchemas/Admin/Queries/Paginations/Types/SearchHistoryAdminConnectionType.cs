using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Queries.Paginations.Types
{
    public class SearchHistoryAdminConnectionType : ObjectType<SearchHistoryAdminConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<SearchHistoryAdminConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
