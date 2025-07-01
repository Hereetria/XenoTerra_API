namespace XenoTerra.DTOLayer.Dtos.PostDtos.Self.Public
{
    public class ResultPostPublicDto
    {
        public Guid PostId { get; init; }
        public string Caption { get; init; } = string.Empty;
        public string Path { get; init; } = string.Empty;
        public bool IsVideo { get; init; }
        public string? Location { get; init; } = string.Empty;
        public Guid UserId { get; init; }
        public DateTime CreatedAt { get; init; }
    }
}