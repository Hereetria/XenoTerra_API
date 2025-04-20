

using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.MessageDtos
{
    public record class ResultMessageWithRelationsDto
    {
        public Guid MessageId { get; init; }
        public string Content { get; init; } = string.Empty;
        public Guid SenderId { get; init; }
        public Guid ReceiverId { get; init; }
        public string Header { get; init; } = string.Empty;
        public DateTime SentAt { get; init; }
        public ResultUserDto Sender { get; init; } = new();
        public ResultUserDto Receiver { get; init; } = new();
    }
}