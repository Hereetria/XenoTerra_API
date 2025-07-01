namespace XenoTerra.DTOLayer.Dtos.MessageDtos.Self.Own
{
    public class ResultMessageOwnDto
    {
        public Guid MessageId { get; init; }
        public string Content { get; init; } = string.Empty;
        public Guid SenderId { get; init; }
        public Guid ReceiverId { get; init; }
        public string Header { get; init; } = string.Empty;
        public DateTime SentAt { get; init; }
    }
}