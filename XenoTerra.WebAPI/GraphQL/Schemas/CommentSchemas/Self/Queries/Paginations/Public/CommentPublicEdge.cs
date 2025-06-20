using XenoTerra.DTOLayer.Dtos.CommentAdminDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Queries.Paginations.Public
{
    public class CommentPublicEdge
    {
        public ResultCommentPublicDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
