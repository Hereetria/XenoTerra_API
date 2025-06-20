using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;

namespace XenoTerra.DTOLayer.Dtos.UserSettingAdminDtos.Self.Own
{
    public class ResultUserSettingWithRelationsOwnDto
    {
        public Guid UserSettingId { get; init; }
        public Guid UserId { get; init; }
        public bool IsPrivate { get; init; }
        public bool ReceiveNotifications { get; init; }
        public bool ShowActivityStatus { get; init; }
        public DateTime LastUpdated { get; init; }
        public ResultAppUserWithRelationsAdminDto User { get; set; } = new();
    }
}