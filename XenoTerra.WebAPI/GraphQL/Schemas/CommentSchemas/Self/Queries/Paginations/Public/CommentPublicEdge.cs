using XenoTerra.DTOLayer.Dtos.CommentDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Queries.Paginations.Public
{
    public class CommentPublicEdge
    {
        public ResultCommentWithRelationsPublicDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
