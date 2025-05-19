using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Admin.Queries.Paginations.Types
{
    public class UserAdminConnectionType : ObjectType<UserAdminConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<UserAdminConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
