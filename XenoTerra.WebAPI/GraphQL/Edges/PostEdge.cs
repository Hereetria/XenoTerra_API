using XenoTerra.DTOLayer.Dtos.PostDtos;

namespace XenoTerra.WebAPI.GraphQL.Edges
{
    public class PostEdge
    {
        public ResultPostWithRelationsDto Node { get; set; }
        public string Cursor { get; set; }
    }
}
