

namespace XenoTerra.DTOLayer.Dtos.NotificationDtos
{
    public class ResultNotificationByIdDto
    {
        public Guid NotificationId { get; set; }
        public Guid UserId { get; set; }
        public Guid Message { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}