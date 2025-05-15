using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Queries.Paginations.Types
{
    public class RoleConnectionType : ObjectType<RoleConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<RoleConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
