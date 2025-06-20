using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Own;

namespace XenoTerra.DTOLayer.Dtos.NotificationAdminDtos.Self.Own
{
    public class ResultNotificationWithRelationsOwnDto
    {
        public Guid NotificationId { get; init; }
        public Guid UserId { get; init; }
        public Guid Message { get; init; }
        public string Image { get; init; } = string.Empty;
        public DateTime CreatedAt { get; init; }
        public ResultAppUserOwnDto User { get; init; } = new();
    }
}