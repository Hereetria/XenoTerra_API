namespace XenoTerra.DTOLayer.Dtos.UserSettingDtos.Self.Own
{
    public class CreateUserSettingOwnDto
    {
        public Guid UserId { get; set; }
        public bool IsPrivate { get; set; }
        public bool ReceiveNotifications { get; set; }
        public bool ShowActivityStatus { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
