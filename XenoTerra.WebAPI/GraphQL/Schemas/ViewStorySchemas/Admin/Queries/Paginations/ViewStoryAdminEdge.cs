using XenoTerra.DTOLayer.Dtos.ViewStoryDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Admin.Queries.Paginations
{
    public class ViewStoryAdminEdge
    {
        public ResultViewStoryWithRelationsAdminDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
