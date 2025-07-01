using XenoTerra.DTOLayer.Dtos.AppUserDtos;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;

namespace XenoTerra.DTOLayer.Dtos.RecentChatsDtos.Admin
{
    public class ResultRecentChatsWithRelationsAdminDto
    {
        public Guid RecentChatsId { get; init; }
        public string LastMessage { get; init; } = string.Empty;
        public Guid UserId { get; init; }
        public DateTime LastMessageAt { get; init; }
        public ICollection<ResultAppUserAdminDto> Users { get; set; } = [];
    }
}