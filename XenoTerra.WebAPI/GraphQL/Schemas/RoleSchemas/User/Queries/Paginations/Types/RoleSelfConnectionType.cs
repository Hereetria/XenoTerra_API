using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Queries.Paginations.Types
{
    public class RoleSelfConnectionType : ObjectType<RoleSelfConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<RoleSelfConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
