using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Queries.Paginations.Types
{
    public class SearchHistoryUserSelfConnectionType : ObjectType<SearchHistoryUserSelfConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<SearchHistoryUserSelfConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
