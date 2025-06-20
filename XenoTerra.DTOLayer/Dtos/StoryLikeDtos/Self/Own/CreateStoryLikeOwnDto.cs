namespace XenoTerra.DTOLayer.Dtos.StoryLikeAdminDtos.Self.Own
{
    public class CreateStoryLikeOwnDto
    {
        public Guid StoryId { get; set; }
        public Guid UserId { get; set; }
        public DateTime LikedAt { get; set; }
    }
}
