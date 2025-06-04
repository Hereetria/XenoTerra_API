using XenoTerra.DTOLayer.Dtos.CommentLikeDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Admin.Queries.Paginations
{
    public class CommentLikeAdminEdge
    {
        public ResultCommentLikeWithRelationsDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
