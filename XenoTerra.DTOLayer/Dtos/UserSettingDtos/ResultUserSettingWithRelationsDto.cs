

using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.UserSettingDtos
{
    public record ResultUserSettingWithRelationsDto(
        Guid UserSettingId,
        Guid UserId,
        bool IsPrivate,
        bool ReceiveNotifications,
        bool ShowActivityStatus,
        DateTime LastUpdated
    )
    {
        public ResultUserWithRelationsDto? User { get; set; }
    }
}