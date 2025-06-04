using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Queries.Paginations.Types
{
    public class LikeSelfEdgeType : ObjectType<CommentLikeSelfEdge>
    {
        protected override void Configure(IObjectTypeDescriptor<CommentLikeSelfEdge> descriptor)
        {
        }
    }
}
