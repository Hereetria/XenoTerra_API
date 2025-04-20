

using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.NotificationDtos
{
    public class CreateNotificationDto
    {
        public Guid UserId { get; set; }
        public Guid Message { get; set; }
        public string Image { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}