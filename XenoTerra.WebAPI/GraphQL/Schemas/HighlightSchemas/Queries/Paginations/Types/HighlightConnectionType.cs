namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Queries.Paginations.Types
{
    public class HighlightConnectionType : ObjectType<HighlightConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<HighlightConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
