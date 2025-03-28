using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.WebAPI.GraphQL.Edges
{
    public class UserEdge
    {
        public ResultUserWithRelationsDto Node { get; set; }
        public string Cursor { get; set; }
    }
}
