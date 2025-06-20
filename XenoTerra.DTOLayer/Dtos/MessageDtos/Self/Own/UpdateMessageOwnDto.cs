namespace XenoTerra.DTOLayer.Dtos.MessageAdminDtos.Self.Own
{
    public class UpdateMessageOwnDto
    {
        public Guid MessageId { get; set; }
        public string? Content { get; set; } = string.Empty; 
        public string? Header { get; set; } = string.Empty;
    }
}
