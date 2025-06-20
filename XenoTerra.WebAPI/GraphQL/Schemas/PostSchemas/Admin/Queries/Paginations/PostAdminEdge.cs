using XenoTerra.DTOLayer.Dtos.PostAdminDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Queries.Paginations
{
    public class PostAdminEdge
    {
        public ResultPostWithRelationsAdminDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
