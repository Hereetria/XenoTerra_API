namespace XenoTerra.DTOLayer.Dtos.NotificationDtos.Self.Own
{
    public class CreateNotificationOwnDto
    {
        public Guid UserId { get; set; }
        public Guid Message { get; set; }
        public string Image { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
