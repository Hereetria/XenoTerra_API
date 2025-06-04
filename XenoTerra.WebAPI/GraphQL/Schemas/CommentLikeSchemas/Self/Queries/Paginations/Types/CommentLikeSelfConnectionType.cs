using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Queries.Paginations.Types
{
    public class CommentLikeSelfConnectionType : ObjectType<CommentLikeSelfConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<CommentLikeSelfConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
