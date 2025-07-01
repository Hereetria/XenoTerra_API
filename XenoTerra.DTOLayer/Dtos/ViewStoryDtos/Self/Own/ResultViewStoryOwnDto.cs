namespace XenoTerra.DTOLayer.Dtos.ViewStoryDtos.Self.Own
{
    public class ResultViewStoryOwnDto
    {
        public Guid ViewStoryId { get; init; }
        public Guid StoryId { get; init; }
        public Guid UserId { get; init; }
        public DateTime ViewedAt { get; init; }
    }
}