

using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.UserSettingDtos
{
    public class UpdateUserSettingDto
    {
        public Guid UserSettingId { get; set; }
        public Guid UserId { get; set; }
        public bool IsPrivate { get; set; }
        public bool ReceiveNotifications { get; set; }
        public bool ShowActivityStatus { get; set; }
        public DateTime LastUpdated { get; set; }

        public ResultUserByIdDto User { get; set; }
    }
}