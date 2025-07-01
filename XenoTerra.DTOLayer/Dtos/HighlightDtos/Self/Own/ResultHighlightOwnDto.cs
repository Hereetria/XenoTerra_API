namespace XenoTerra.DTOLayer.Dtos.HighlightDtos.Self.Own
{
    public class ResultHighlightOwnDto
    {
        public Guid HighlightId { get; init; }
        public string Name { get; init; } = string.Empty;
        public string ProfilePicturePath { get; init; } = string.Empty;
        public Guid UserId { get; init; }
    }
}