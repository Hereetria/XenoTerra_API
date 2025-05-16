using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Queries.Paginations.Types
{
    public class UserPostTagAdminConnectionType : ObjectType<UserPostTagAdminConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<UserPostTagAdminConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
