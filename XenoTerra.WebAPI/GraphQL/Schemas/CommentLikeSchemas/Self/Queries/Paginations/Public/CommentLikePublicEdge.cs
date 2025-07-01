using XenoTerra.DTOLayer.Dtos.CommentLikeDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Queries.Paginations.Public
{
    public class CommentLikePublicEdge
    {
        public ResultCommentLikeWithRelationsPublicDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
