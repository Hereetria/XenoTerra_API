using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.SearchHistoryDtos
{
    public record ResultSearchHistoryWithRelationsDto(
        Guid SearchHistoryId,
        Guid UserId,
        DateTime SearchedAt
    )
    {
        public ResultUserDto? User { get; set; }
        public ICollection<ResultUserDto>? SearchedUsers { get; set; }
    }
}