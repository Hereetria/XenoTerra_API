using XenoTerra.DTOLayer.Dtos.CommentDtos;

namespace XenoTerra.WebAPI.GraphQL.Edges
{
    public class CommentEdge
    {
        public ResultCommentWithRelationsDto Node { get; set; }
        public string Cursor { get; set; }
    }
}
