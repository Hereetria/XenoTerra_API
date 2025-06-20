using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Own;

namespace XenoTerra.DTOLayer.Dtos.MessageAdminDtos.Self.Own
{
    public class ResultMessageWithRelationsOwnDto
    {
        public Guid MessageId { get; init; }
        public string Content { get; init; } = string.Empty;
        public Guid SenderId { get; init; }
        public Guid ReceiverId { get; init; }
        public string Header { get; init; } = string.Empty;
        public DateTime SentAt { get; init; }
        public ResultAppUserOwnDto Sender { get; init; } = new();
        public ResultAppUserOwnDto Receiver { get; init; } = new();
    }
}