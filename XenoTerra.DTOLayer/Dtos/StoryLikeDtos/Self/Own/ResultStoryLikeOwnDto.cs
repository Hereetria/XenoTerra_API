namespace XenoTerra.DTOLayer.Dtos.StoryLikeAdminDtos.Self.Own
{
    public class ResultStoryLikeOwnDto
    {
        public Guid StoryLikeId { get; set; }
        public Guid StoryId { get; set; }
        public Guid UserId { get; set; }
        public DateTime LikedAt { get; set; }
    }
}