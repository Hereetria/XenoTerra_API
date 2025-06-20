namespace XenoTerra.DTOLayer.Dtos.SavedPostAdminDtos.Admin
{
    public class UpdateSavedPostAdminDto
    {
        public Guid SavedPostId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? PostId { get; set; }
    }
}