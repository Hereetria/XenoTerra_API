namespace XenoTerra.DTOLayer.Dtos.SavedPostDtos.Admin
{
    public class CreateSavedPostAdminDto
    {
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
        public DateTime SavedAt { get; set; }
    }
}