using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Queries.Paginations.Types
{
    public class SearchHistoryUserConnectionType : ObjectType<SearchHistoryUserConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<SearchHistoryUserConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
