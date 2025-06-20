using XenoTerra.DTOLayer.Dtos.CommentLikeAdminDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Queries.Paginations.Own
{
    public class CommentLikeOwnEdge
    {
        public ResultCommentLikeWithRelationsOwnDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
