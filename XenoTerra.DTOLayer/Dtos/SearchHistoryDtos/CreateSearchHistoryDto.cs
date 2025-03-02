

namespace XenoTerra.DTOLayer.Dtos.SearchHistoryDtos
{
    public class CreateSearchHistoryDto
    {
        public Guid UserId { get; set; }
        public DateTime SearchedAt { get; set; }
    }
}