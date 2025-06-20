using XenoTerra.DTOLayer.Dtos.CommentAdminDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Queries.Paginations
{
    public class CommentAdminEdge
    {
        public ResultCommentWithRelationsAdminDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
