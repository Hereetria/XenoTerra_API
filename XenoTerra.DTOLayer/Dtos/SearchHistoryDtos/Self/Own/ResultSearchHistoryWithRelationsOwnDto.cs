using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;

namespace XenoTerra.DTOLayer.Dtos.SearchHistoryAdminDtos.Self.Own
{
    public class ResultSearchHistoryWithRelationsOwnDto
    {
        public Guid SearchHistoryId { get; init; }
        public Guid UserId { get; init; }
        public DateTime SearchedAt { get; init; }
        public ResultAppUserAdminDto User { get; set; } = new();
        public ICollection<ResultAppUserAdminDto> SearchedUsers { get; set; } = [];
    }
}