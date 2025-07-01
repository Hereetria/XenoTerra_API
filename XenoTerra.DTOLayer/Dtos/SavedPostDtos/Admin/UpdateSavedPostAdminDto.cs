namespace XenoTerra.DTOLayer.Dtos.SavedPostDtos.Admin
{
    public class UpdateSavedPostAdminDto
    {
        public Guid SavedPostId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? PostId { get; set; }
    }
}