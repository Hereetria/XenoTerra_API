
namespace XenoTerra.DTOLayer.Dtos.HighlightAdminDtos.Admin
{
    public class UpdateHighlightAdminDto
    {
        public Guid HighlightId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ProfilePicturePath { get; set; } = string.Empty;
        public Guid UserId { get; set; }
    }
}