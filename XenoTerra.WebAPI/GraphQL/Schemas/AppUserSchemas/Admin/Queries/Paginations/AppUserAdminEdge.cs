using XenoTerra.DTOLayer.Dtos.AppUserDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Admin.Queries.Paginations
{
    public class AppUserAdminEdge
    {
        public ResultAppUserWithRelationsPrivateDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
