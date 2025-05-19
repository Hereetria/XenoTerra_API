using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Admin.Queries.Paginations
{
    public class UserAdminEdge
    {
        public ResultUserWithRelationsPrivateDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
