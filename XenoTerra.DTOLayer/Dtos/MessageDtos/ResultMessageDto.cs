

using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.MessageDtos
{
    public class ResultMessageDto
    {
        public Guid MessageId { get; set; }
        public string Content { get; set; }
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public string Header { get; set; }
        public DateTime SentAt { get; set; }

        public ResultUserByIdDto Sender { get; set; }
        public ResultUserByIdDto Receiver { get; set; }
    }
}