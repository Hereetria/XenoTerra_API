

using XenoTerra.DTOLayer.Dtos.AppUserDtos;

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
        public ResultAppUserPrivateDto Sender { get; init; } = new();
        public ResultAppUserPrivateDto Receiver { get; init; } = new();
    }
}