using XenoTerra.DTOLayer.Dtos.AppUserDtos;

namespace XenoTerra.DTOLayer.Dtos.SearchHistoryDtos
{
    public record class ResultSearchHistoryWithRelationsDto
    {
        public Guid SearchHistoryId { get; init; }
        public Guid UserId { get; init; }
        public DateTime SearchedAt { get; init; }
        public ResultAppUserPrivateDto User { get; init; } = new();
        public ICollection<ResultAppUserPrivateDto> SearchedUsers { get; init; } = [];
    }
}