

using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos;
using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.SearchHistoryDtos
{
    public class CreateSearchHistoryDto
    {
        public Guid UserId { get; set; }
        public DateTime SearchedAt { get; set; }

        public ResultUserByIdDto User { get; set; }
        public ICollection<ResultSearchHistoryUserByIdDto> SearchedUsers { get; set; }
    }
}