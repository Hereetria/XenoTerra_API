

using XenoTerra.DTOLayer.Dtos.AppUserDtos;

namespace XenoTerra.DTOLayer.Dtos.UserSettingDtos
{
    public record class ResultUserSettingWithRelationsDto
    {
        public Guid UserSettingId { get; init; }
        public Guid UserId { get; init; }
        public bool IsPrivate { get; init; }
        public bool ReceiveNotifications { get; init; }
        public bool ShowActivityStatus { get; init; }
        public DateTime LastUpdated { get; init; }
        public ResultAppUserWithRelationsPrivateDto User { get; init; } = new();
    }
}