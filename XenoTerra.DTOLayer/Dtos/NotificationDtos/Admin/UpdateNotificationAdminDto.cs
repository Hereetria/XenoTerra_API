namespace XenoTerra.DTOLayer.Dtos.NotificationDtos.Admin
{
    public class UpdateNotificationAdminDto
    {
        public Guid NotificationId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? Message { get; set; }
        public string? Image { get; set; } = string.Empty;
    }
}