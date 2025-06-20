namespace XenoTerra.DTOLayer.Dtos.MessageAdminDtos.Self.Own
{
    public class CreateMessageOwnDto
    {
        public string Content { get; set; } = string.Empty;
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public string Header { get; set; } = string.Empty;
        public DateTime SentAt { get; set; }
    }
}
