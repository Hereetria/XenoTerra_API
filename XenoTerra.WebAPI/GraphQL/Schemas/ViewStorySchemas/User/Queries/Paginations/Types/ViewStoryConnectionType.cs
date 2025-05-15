namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Queries.Paginations.Types
{
    public class ViewStoryConnectionType : ObjectType<ViewStoryConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<ViewStoryConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
