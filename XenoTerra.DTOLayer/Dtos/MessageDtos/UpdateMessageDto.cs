

namespace XenoTerra.DTOLayer.Dtos.MessageDtos
{
    public class UpdateMessageDto
    {
        public Guid MessageId { get; set; }
        public string Content { get; set; }
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public DateTime SentAt { get; set; }
    }
}