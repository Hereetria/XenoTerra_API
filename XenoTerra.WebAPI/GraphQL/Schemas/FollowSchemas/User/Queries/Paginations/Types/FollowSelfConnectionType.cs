using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Queries.Paginations.Types
{
    public class FollowSelfConnectionType : ObjectType<FollowSelfConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<FollowSelfConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
