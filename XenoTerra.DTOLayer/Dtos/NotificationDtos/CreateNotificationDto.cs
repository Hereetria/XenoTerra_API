

namespace XenoTerra.DTOLayer.Dtos.NotificationDtos
{
    public class CreateNotificationDto
    {
        public Guid UserId { get; set; }
        public Guid Message { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}