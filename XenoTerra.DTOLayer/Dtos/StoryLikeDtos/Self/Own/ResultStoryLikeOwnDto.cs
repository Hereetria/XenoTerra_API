namespace XenoTerra.DTOLayer.Dtos.StoryLikeDtos.Self.Own
{
    public class ResultStoryLikeOwnDto
    {
        public Guid StoryLikeId { get; init; }
        public Guid StoryId { get; init; }
        public Guid UserId { get; init; }
        public DateTime LikedAt { get; init; }
    }
}