using XenoTerra.DTOLayer.Dtos.AppUserDtos;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;

namespace XenoTerra.DTOLayer.Dtos.MessageAdminDtos.Admin
{
    public class ResultMessageWithRelationsAdminDto
    {
        public Guid MessageId { get; init; }
        public string Content { get; init; } = string.Empty;
        public Guid SenderId { get; init; }
        public Guid ReceiverId { get; init; }
        public string Header { get; init; } = string.Empty;
        public DateTime SentAt { get; init; }
        public ResultAppUserAdminDto Sender { get; init; } = new();
        public ResultAppUserAdminDto Receiver { get; init; } = new();
    }
}