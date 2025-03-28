using XenoTerra.DTOLayer.Dtos.RoleDtos;

namespace XenoTerra.WebAPI.GraphQL.Edges
{
    public class RoleEdge
    {
        public ResultRoleWithRelationsDto Node { get; set; }
        public string Cursor { get; set; }
    }
}
