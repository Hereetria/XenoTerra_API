

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
        public ResultUserPrivateDto Sender { get; init; } = new();
        public ResultUserPrivateDto Receiver { get; init; } = new();
    }
}