using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.SearchHistoryDtos
{
    public record class ResultSearchHistoryWithRelationsDto
    {
        public Guid SearchHistoryId { get; init; }
        public Guid UserId { get; init; }
        public DateTime SearchedAt { get; init; }
        public ResultUserPrivateDto User { get; init; } = new();
        public ICollection<ResultUserPrivateDto> SearchedUsers { get; init; } = [];
    }
}