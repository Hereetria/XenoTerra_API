using XenoTerra.DTOLayer.Dtos.CommentAdminDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Queries.Paginations.Own
{
    public class CommentOwnEdge
    {
        public ResultCommentWithRelationsOwnDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
