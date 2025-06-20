namespace XenoTerra.DTOLayer.Dtos.NotificationAdminDtos.Self.Public
{
    public class ResultNotificationPublicDto
    {
        public Guid NotificationId { get; init; }
        public Guid UserId { get; init; }
        public Guid Message { get; init; }
        public string Image { get; init; } = string.Empty;
        public DateTime CreatedAt { get; init; }
    }
}