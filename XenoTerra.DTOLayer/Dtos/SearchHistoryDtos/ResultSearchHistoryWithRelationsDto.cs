using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.SearchHistoryDtos
{
    public record class ResultSearchHistoryWithRelationsDto
    {
        public Guid SearchHistoryId { get; init; }
        public Guid UserId { get; init; }
        public DateTime SearchedAt { get; init; }
        public ResultUserDto User { get; init; } = new();
        public ICollection<ResultUserDto> SearchedUsers { get; init; } = [];
    }
}