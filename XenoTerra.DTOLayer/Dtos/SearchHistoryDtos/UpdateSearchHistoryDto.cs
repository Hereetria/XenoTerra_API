namespace XenoTerra.DTOLayer.Dtos.SearchHistoryDtos
{
    public class UpdateSearchHistoryDto
    {
        public Guid SearchHistoryId { get; set; }
        public Guid? UserId { get; set; }
        public DateTime? SearchedAt { get; set; }
    }
}