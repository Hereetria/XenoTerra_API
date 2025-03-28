

using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.MessageDtos
{
    public class CreateMessageDto
    {
        public required string Content { get; set; }
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public required string Header { get; set; }
        public DateTime SentAt { get; set; }
    }
}