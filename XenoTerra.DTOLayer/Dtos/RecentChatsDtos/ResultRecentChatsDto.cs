

namespace XenoTerra.DTOLayer.Dtos.RecentChatsDtos
{
    public class ResultRecentChatsDto
    {
        public Guid RecentChatsId { get; set; }
        public string LastMessage { get; set; }
        public Guid UserId { get; set; }
        public DateTime LastMessageAt { get; set; }
    }
}