namespace XenoTerra.DTOLayer.Dtos.UserSettingAdminDtos.Self.Own
{
    public class UpdateUserSettingOwnDto
    {
        public Guid UserSettingId { get; set; }
        public bool? IsPrivate { get; set; }
        public bool? ReceiveNotifications { get; set; }
        public bool? ShowActivityStatus { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
