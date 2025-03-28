

using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.RecentChatsDtos
{
    public class CreateRecentChatsDto
    {
        public required string LastMessage { get; set; }
        public Guid UserId { get; set; }
        public DateTime LastMessageAt { get; set; }
    }
}