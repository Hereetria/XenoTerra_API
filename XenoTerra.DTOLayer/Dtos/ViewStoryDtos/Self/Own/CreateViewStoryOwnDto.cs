namespace XenoTerra.DTOLayer.Dtos.ViewStoryDtos.Self.Own
{
    public class CreateViewStoryOwnDto
    {
        public Guid StoryId { get; set; }
        public Guid UserId { get; set; }
        public DateTime ViewedAt { get; set; }
    }
}
