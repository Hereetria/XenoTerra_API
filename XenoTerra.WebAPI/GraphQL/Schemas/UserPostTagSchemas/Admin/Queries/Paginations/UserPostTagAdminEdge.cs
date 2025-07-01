using XenoTerra.DTOLayer.Dtos.UserPostTagDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Queries.Paginations
{
    public class UserPostTagAdminEdge
    {
        public ResultUserPostTagWithRelationsAdminDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
