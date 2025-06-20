using XenoTerra.DTOLayer.Dtos.HighlightAdminDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.StoryAdminDtos.Self.Own;

namespace XenoTerra.DTOLayer.Dtos.StoryHighlightAdminDtos.Self.Own
{
    public class ResultStoryHighlightWithRelationsOwnDto
    {
        public Guid StoryId { get; init; }
        public Guid HighlightId { get; init; }
        public ResultStoryOwnDto Story { get; set; } = new();
        public ResultHighlightOwnDto Highlight { get; set; } = new();
    }
}