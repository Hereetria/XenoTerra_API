

using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.MessageDtos
{
    public class UpdateMessageDto
    {
        public Guid MessageId { get; set; }
        public string? Content { get; set; } = string.Empty;
        public Guid? SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public string? Header { get; set; } = string.Empty;
    }
}