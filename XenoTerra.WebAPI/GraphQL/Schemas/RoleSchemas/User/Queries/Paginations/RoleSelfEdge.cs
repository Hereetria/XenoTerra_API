using XenoTerra.DTOLayer.Dtos.RoleDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Queries.Paginations
{
    public class RoleSelfEdge
    {
        public ResultRoleWithRelationsDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
