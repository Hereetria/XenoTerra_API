using XenoTerra.DTOLayer.Dtos.HighlightDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.StoryDtos.Self.Own;

namespace XenoTerra.DTOLayer.Dtos.StoryHighlightDtos.Self.Own
{
    public class ResultStoryHighlightWithRelationsOwnDto
    {
        public Guid StoryId { get; init; }
        public Guid HighlightId { get; init; }
        public ResultStoryOwnDto Story { get; set; } = new();
        public ResultHighlightOwnDto Highlight { get; set; } = new();
    }
}