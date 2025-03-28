

using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.NotificationDtos
{
    public record ResultNotificationWithRelationsDto(
        Guid NotificationId,
        Guid UserId,
        Guid Message,
        string Image,
        DateTime CreatedAt
    )
    {
        public ResultUserDto? User { get; set; }
    }
}