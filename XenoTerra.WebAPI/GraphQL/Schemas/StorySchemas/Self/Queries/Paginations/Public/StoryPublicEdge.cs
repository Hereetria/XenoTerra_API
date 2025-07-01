using XenoTerra.DTOLayer.Dtos.StoryDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Queries.Paginations.Public
{
    public class StoryPublicEdge
    {
        public ResultStoryWithRelationsPublicDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
