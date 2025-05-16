using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Queries.Paginations.Types
{
    public class RoleAdminConnectionType : ObjectType<RoleAdminConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<RoleAdminConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
