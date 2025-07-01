namespace XenoTerra.DTOLayer.Dtos.MediaDtos.Self.Own
{
    public class ResultMediaOwnDto
    {
        public Guid MediaId { get; init; }
        public string PhotoUrl { get; init; } = string.Empty;

        public Guid SenderId { get; init; }

        public Guid ReceiverId { get; init; }

        public DateTime UploadedAt { get; init; }
    }
}