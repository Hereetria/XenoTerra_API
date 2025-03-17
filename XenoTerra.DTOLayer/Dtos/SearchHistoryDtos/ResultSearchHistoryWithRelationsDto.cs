using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.SearchHistoryDtos
{
    public class ResultSearchHistoryWithRelationsDto
    {
        public Guid SearchHistoryId { get; set; }
        public Guid UserId { get; set; }
        public DateTime SearchedAt { get; set; }

        public ResultUserDto User { get; set; }
        public ICollection<ResultUserDto> SearchedUsers { get; set; }
    }
}