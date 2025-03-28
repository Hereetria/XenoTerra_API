using XenoTerra.DTOLayer.Dtos.StoryHighlightDtos;

namespace XenoTerra.WebAPI.GraphQL.Edges
{
    public class StoryHighlightEdge
    {
        public ResultStoryHighlightWithRelationsDto Node { get; set; }
        public string Cursor { get; set; }
    }
}
