namespace XenoTerra.DTOLayer.Dtos.RecentChatsAdminDtos.Admin
{
    public class CreateRecentChatsAdminDto
    {
        public string LastMessage { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public DateTime LastMessageAt { get; set; }
    }
}