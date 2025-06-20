using XenoTerra.DTOLayer.Dtos.StoryAdminDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Queries.Paginations.Public
{
    public class StoryPublicEdge
    {
        public ResultStoryPublicDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
