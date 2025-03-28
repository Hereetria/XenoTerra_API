

using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.RecentChatsDtos
{
    public record ResultRecentChatsWithRelationsDto(
        Guid RecentChatsId,
        string LastMessage,
        Guid UserId,
        DateTime LastMessageAt
    )
    {
        public ICollection<ResultUserDto>? Users { get; set; }
    }
}