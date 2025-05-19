namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Admin.Queries.Paginations.Types
{
    public class ViewStoryAdminConnectionType : ObjectType<ViewStoryAdminConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<ViewStoryAdminConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
