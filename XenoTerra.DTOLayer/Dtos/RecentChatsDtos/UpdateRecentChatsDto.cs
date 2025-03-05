

using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.RecentChatsDtos
{
    public class UpdateRecentChatsDto
    {
        public Guid RecentChatsId { get; set; }
        public string LastMessage { get; set; }
        public Guid UserId { get; set; }
        public DateTime LastMessageAt { get; set; }

        public ICollection<ResultUserByIdDto> Users { get; set; }
    }
}