

using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.NotificationDtos
{
    public class UpdateNotificationDto
    {
        public Guid NotificationId { get; set; }
        public Guid UserId { get; set; }
        public Guid Message { get; set; }
        public required string Image { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}