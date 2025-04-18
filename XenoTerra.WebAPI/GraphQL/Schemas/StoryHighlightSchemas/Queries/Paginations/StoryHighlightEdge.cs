using XenoTerra.DTOLayer.Dtos.StoryHighlightDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Queries.Paginations
{
    public class StoryHighlightEdge
    {
        public ResultStoryHighlightWithRelationsDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
