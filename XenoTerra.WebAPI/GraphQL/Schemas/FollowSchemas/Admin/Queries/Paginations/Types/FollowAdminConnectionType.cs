using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Queries.Paginations.Types
{
    public class FollowAdminConnectionType : ObjectType<FollowAdminConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<FollowAdminConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
