namespace XenoTerra.DTOLayer.Dtos.SearchHistoryDtos.Admin
{
    public class UpdateSearchHistoryAdminDto
    {
        public Guid SearchHistoryId { get; set; }
        public Guid? UserId { get; set; }
        public DateTime? SearchedAt { get; set; }
    }
}