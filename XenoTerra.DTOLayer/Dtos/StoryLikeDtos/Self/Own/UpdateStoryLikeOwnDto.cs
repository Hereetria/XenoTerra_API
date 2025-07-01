namespace XenoTerra.DTOLayer.Dtos.StoryLikeDtos.Self.Own
{
    public class UpdateStoryLikeOwnDto
    {
        public Guid StoryLikeId { get; set; }
        public Guid StoryId { get; set; }
        public DateTime LikedAt { get; set; }
    }
}
