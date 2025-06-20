using XenoTerra.DTOLayer.Dtos.StoryAdminDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Queries.Paginations
{
    public class StoryAdminEdge
    {
        public ResultStoryWithRelationsAdminDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
