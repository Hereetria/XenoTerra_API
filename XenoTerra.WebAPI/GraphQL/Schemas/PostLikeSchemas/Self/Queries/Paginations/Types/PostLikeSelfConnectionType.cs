using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Queries.Paginations.Types
{
    public class PostLikeSelfConnectionType : ObjectType<PostLikeSelfConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<PostLikeSelfConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
