using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;

namespace XenoTerra.DTOLayer.Dtos.RecentChatsAdminDtos.Self.Own
{
    public class ResultRecentChatsWithRelationsOwnDto
    {
        public Guid RecentChatsId { get; init; }
        public string LastMessage { get; init; } = string.Empty;
        public DateTime LastMessageAt { get; init; }
        public ICollection<ResultAppUserAdminDto> Users { get; set; } = [];
    }
}