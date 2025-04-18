namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Queries.Paginations.Types
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
