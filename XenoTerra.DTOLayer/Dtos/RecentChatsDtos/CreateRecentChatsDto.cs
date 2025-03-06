

using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.RecentChatsDtos
{
    public class CreateRecentChatsDto
    {
        public string LastMessage { get; set; }
        public Guid UserId { get; set; }
        public DateTime LastMessageAt { get; set; }
    }
}