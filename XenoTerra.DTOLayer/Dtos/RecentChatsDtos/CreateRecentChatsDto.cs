


namespace XenoTerra.DTOLayer.Dtos.RecentChatsDtos
{
    public class CreateRecentChatsDto
    {
        public string LastMessage { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public DateTime LastMessageAt { get; set; }
    }
}