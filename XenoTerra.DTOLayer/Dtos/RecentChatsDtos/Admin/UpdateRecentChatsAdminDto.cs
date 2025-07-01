namespace XenoTerra.DTOLayer.Dtos.RecentChatsDtos.Admin
{
    public class UpdateRecentChatsAdminDto
    {
        public Guid RecentChatsId { get; set; }
        public string? LastMessage { get; set; } = string.Empty;
        public Guid? UserId { get; set; }
        public DateTime? LastMessageAt { get; set; }
    }
}