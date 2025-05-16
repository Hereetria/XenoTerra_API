namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Queries.Paginations.Types
{
    public class ViewStorySelfConnectionType : ObjectType<ViewStorySelfConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<ViewStorySelfConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
