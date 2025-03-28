using XenoTerra.DTOLayer.Dtos.FollowDtos;

namespace XenoTerra.WebAPI.GraphQL.Edges
{
    public class FollowEdge
    {
        public ResultFollowWithRelationsDto Node { get; set; }
        public string Cursor { get; set; }
    }
}
