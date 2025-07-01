namespace XenoTerra.DTOLayer.Dtos.MessageDtos.Admin
{
    public class UpdateMessageAdminDto
    {
        public Guid MessageId { get; set; }
        public string? Content { get; set; } = string.Empty;
        public Guid? SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public string? Header { get; set; } = string.Empty;
    }
}