using XenoTerra.DTOLayer.Dtos.RoleDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Queries.Paginations
{
    public class RoleEdge
    {
        public ResultRoleWithRelationsDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
