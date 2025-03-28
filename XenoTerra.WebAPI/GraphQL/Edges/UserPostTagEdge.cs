using XenoTerra.DTOLayer.Dtos.UserPostTagDtos;

namespace XenoTerra.WebAPI.GraphQL.Edges
{
    public class UserPostTagEdge
    {
        public ResultUserPostTagWithRelationsDto Node { get; set; }
        public string Cursor { get; set; }
    }
}
