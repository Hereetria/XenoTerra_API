namespace XenoTerra.DTOLayer.Dtos.StoryLikeDtos.Self.Own
{
    public class CreateStoryLikeOwnDto
    {
        public Guid StoryId { get; set; }
        public Guid UserId { get; set; }
        public DateTime LikedAt { get; set; }
    }
}
