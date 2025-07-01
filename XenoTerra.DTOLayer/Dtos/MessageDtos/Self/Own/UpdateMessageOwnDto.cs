namespace XenoTerra.DTOLayer.Dtos.MessageDtos.Self.Own
{
    public class UpdateMessageOwnDto
    {
        public Guid MessageId { get; set; }
        public string? Content { get; set; } = string.Empty; 
        public string? Header { get; set; } = string.Empty;
    }
}
