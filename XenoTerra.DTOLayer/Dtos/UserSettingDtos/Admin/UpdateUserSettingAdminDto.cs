namespace XenoTerra.DTOLayer.Dtos.UserSettingAdminDtos.Admin
{
    public class UpdateUserSettingAdminDto
    {
        public Guid UserSettingId { get; set; }
        public Guid? UserId { get; set; }
        public bool? IsPrivate { get; set; }
        public bool? ReceiveNotifications { get; set; }
        public bool? ShowActivityStatus { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}