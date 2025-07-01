using XenoTerra.DTOLayer.Dtos.CommentLikeDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Admin.Queries.Paginations
{
    public class CommentLikeAdminEdge
    {
        public ResultCommentLikeWithRelationsAdminDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
