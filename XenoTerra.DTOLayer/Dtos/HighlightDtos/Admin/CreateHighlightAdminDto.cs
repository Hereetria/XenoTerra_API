namespace XenoTerra.DTOLayer.Dtos.HighlightDtos.Admin
{
    public class CreateHighlightAdminDto
    {
        public string Name { get; set; } = string.Empty;
        public string ProfilePicturePath { get; set; } = string.Empty;
        public Guid UserId { get; set; }
    }
}