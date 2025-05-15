using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Queries.Paginations.Types
{
    public class FollowConnectionType : ObjectType<FollowConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<FollowConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
