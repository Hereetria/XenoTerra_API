

using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.RecentChatsDtos
{
    public record class ResultRecentChatsWithRelationsDto
    {
        public Guid RecentChatsId { get; init; }
        public string LastMessage { get; init; } = string.Empty;
        public Guid UserId { get; init; }
        public DateTime LastMessageAt { get; init; }
        public ICollection<ResultUserPrivateDto> Users { get; init; } = [];
    }
}