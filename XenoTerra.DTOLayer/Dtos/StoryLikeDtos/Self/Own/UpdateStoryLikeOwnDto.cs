namespace XenoTerra.DTOLayer.Dtos.StoryLikeAdminDtos.Self.Own
{
    public class UpdateStoryLikeOwnDto
    {
        public Guid StoryLikeId { get; set; }
        public Guid StoryId { get; set; }
        public DateTime LikedAt { get; set; }
    }
}
