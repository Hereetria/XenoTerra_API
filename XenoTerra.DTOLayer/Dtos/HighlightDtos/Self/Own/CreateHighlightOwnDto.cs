namespace XenoTerra.DTOLayer.Dtos.HighlightAdminDtos.Self.Own
{
    public class CreateHighlightOwnDto
    {
        public string Name { get; set; } = string.Empty;
        public string ProfilePicturePath { get; set; } = string.Empty;
        public Guid UserId { get; set; }
    }
}
