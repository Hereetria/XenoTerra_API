namespace XenoTerra.DTOLayer.Dtos.RecentChatsDtos.Self.Own
{
    public class UpdateRecentChatsOwnDto
    {
        public Guid RecentChatsId { get; set; }
        public string? LastMessage { get; set; } = string.Empty;
        public DateTime? LastMessageAt { get; set; }
    }
}
