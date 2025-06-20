namespace XenoTerra.DTOLayer.Dtos.RecentChatsAdminDtos.Self.Own
{
    public class CreateRecentChatsOwnDto
    {
        public string LastMessage { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public DateTime LastMessageAt { get; set; }
    }
}
