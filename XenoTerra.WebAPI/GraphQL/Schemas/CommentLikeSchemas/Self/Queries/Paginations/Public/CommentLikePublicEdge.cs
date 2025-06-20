using XenoTerra.DTOLayer.Dtos.CommentLikeAdminDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Queries.Paginations.Public
{
    public class CommentLikePublicEdge
    {
        public ResultCommentLikePublicDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
