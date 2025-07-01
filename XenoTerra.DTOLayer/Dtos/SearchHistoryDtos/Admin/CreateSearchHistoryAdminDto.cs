namespace XenoTerra.DTOLayer.Dtos.SearchHistoryDtos.Admin
{
    public class CreateSearchHistoryAdminDto
    {
        public Guid UserId { get; set; }
        public DateTime SearchedAt { get; set; }
    }
}