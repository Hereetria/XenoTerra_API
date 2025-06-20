using XenoTerra.DTOLayer.Dtos.ViewStoryAdminDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Admin.Queries.Paginations
{
    public class ViewStoryAdminEdge
    {
        public ResultViewStoryWithRelationsAdminDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
