using XenoTerra.DTOLayer.Dtos.AppRoleDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppRoleSchemas.Admin.Queries.Paginations
{
    public class AppRoleAdminEdge
    {
        public ResultAppRoleWithRelationsDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
