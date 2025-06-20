namespace XenoTerra.DTOLayer.Dtos.NotificationAdminDtos.Admin
{
    public class CreateNotificationAdminDto
    {
        public Guid UserId { get; set; }
        public Guid Message { get; set; }
        public string Image { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}