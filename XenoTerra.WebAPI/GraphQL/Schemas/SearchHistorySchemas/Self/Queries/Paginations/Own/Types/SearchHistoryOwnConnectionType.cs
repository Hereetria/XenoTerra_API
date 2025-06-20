using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Self.Queries.Paginations.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Self.Queries.Paginations.Own.Types
{
    public class SearchHistoryOwnConnectionType : ObjectType<SearchHistoryOwnConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<SearchHistoryOwnConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
