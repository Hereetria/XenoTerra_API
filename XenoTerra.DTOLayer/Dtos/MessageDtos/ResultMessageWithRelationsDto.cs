

using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.MessageDtos
{
    public record ResultMessageWithRelationsDto(
        Guid MessageId,
        string Content,
        Guid SenderId,
        Guid ReceiverId,
        string Header,
        DateTime SentAt
    )
    {
        public ResultUserDto? Sender { get; set; }
        public ResultUserDto? Receiver { get; set; }
    }
}