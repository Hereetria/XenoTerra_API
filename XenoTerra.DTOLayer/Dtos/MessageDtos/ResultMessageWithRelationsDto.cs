

using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.MessageDtos
{
    public class ResultMessageWithRelationsDto
    {
        public Guid MessageId { get; set; }
        public string Content { get; set; }
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public string Header { get; set; }
        public DateTime SentAt { get; set; }

        public ResultUserDto Sender { get; set; }
        public ResultUserDto Receiver { get; set; }
    }
}