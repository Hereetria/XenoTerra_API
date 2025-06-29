using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.MessageAdminDtos.Admin;

namespace XenoTerra.DTOLayer.Dtos.ReactionAdminDtos.Self.Own
{
    public class ResultReactionWithRelationsOwnDto
    {
        public Guid ReactionId { get; init; }
        public string Payload { get; init; } = string.Empty;
        public Guid MessageId { get; init; }
        public Guid UserId { get; init; }
        public ResultMessageAdminDto Message { get; set; } = new();
        public ResultAppUserAdminDto User { get; set; } = new();
    }
}