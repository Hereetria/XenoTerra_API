using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Queries.Paginations.Types
{
    public class SearchHistoryUserAdminConnectionType : ObjectType<SearchHistoryUserAdminConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<SearchHistoryUserAdminConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
