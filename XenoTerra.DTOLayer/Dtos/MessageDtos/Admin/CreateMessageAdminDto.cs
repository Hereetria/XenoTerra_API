namespace XenoTerra.DTOLayer.Dtos.MessageAdminDtos.Admin
{
    public class CreateMessageAdminDto
    {
        public string Content { get; set; } = string.Empty;
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public string Header { get; set; } = string.Empty;
        public DateTime SentAt { get; set; }
    }
}