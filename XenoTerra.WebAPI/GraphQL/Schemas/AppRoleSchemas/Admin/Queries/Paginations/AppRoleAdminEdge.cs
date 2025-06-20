using XenoTerra.DTOLayer.Dtos.AppRoleDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppRoleSchemas.Admin.Queries.Paginations
{
    public class AppRoleAdminEdge
    {
        public ResultAppRoleWithRelationsAdminDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
