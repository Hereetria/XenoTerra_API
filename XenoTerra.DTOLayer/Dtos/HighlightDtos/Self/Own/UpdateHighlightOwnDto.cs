namespace XenoTerra.DTOLayer.Dtos.HighlightAdminDtos.Self.Own
{
    public class UpdateHighlightOwnDto
    {
        public Guid HighlightId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ProfilePicturePath { get; set; } = string.Empty;
    }
}
