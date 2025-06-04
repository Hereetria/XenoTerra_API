namespace XenoTerra.WebAPI.GraphQL.Schemas.AppRoleSchemas.Admin.Queries.Paginations.Types
{
    public class AppRoleAdminConnectionType : ObjectType<AppRoleAdminConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<AppRoleAdminConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
