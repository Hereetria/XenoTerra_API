using XenoTerra.DTOLayer.Dtos.LikeDtos;

namespace XenoTerra.WebAPI.GraphQL.Edges
{
    public class LikeEdge
    {
        public ResultLikeWithRelationsDto Node { get; set; }
        public string Cursor { get; set; }
    }
}
