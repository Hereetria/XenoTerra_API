namespace XenoTerra.DTOLayer.Dtos.SearchHistoryAdminDtos.Admin
{
    public class CreateSearchHistoryAdminDto
    {
        public Guid UserId { get; set; }
        public DateTime SearchedAt { get; set; }
    }
}