namespace XenoTerra.DTOLayer.Dtos.StoryDtos.Self.Public
{
    public class ResultStoryPublicDto
    {
        public Guid StoryId { get; init; }
        public string Path { get; init; } = string.Empty;
        public bool IsVideo { get; init; }
        public Guid UserId { get; init; }
        public DateTime CreatedAt { get; init; }
    }
}