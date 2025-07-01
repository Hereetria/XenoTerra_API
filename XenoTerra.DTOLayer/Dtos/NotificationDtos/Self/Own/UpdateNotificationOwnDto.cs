namespace XenoTerra.DTOLayer.Dtos.NotificationDtos.Self.Own
{
    public class UpdateNotificationOwnDto
    {
        public Guid NotificationId { get; set; }
        public Guid? Message { get; set; }
        public string? Image { get; set; } = string.Empty;
    }
}
