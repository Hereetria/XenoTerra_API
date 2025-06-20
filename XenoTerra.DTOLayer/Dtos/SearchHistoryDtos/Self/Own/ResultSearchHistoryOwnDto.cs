namespace XenoTerra.DTOLayer.Dtos.SearchHistoryAdminDtos.Self.Own
{
    public class ResultSearchHistoryOwnDto
    {
        public Guid SearchHistoryId { get; init; }
        public Guid UserId { get; init; }
        public DateTime SearchedAt { get; init; }
    }
}