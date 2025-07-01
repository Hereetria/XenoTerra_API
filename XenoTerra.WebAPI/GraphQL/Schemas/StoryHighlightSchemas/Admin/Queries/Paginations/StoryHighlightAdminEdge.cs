using XenoTerra.DTOLayer.Dtos.StoryHighlightDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Queries.Paginations
{
    public class StoryHighlightAdminEdge
    {
        public ResultStoryHighlightWithRelationsAdminDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
