

using XenoTerra.DTOLayer.Dtos.AppUserDtos;
using XenoTerra.DTOLayer.Dtos.MessageDtos;

namespace XenoTerra.DTOLayer.Dtos.ReactionDtos
{
    public record class ResultReactionWithRelationsDto
    {
        public Guid ReactionId { get; init; }
        public string Payload { get; init; } = string.Empty;
        public Guid MessageId { get; init; }
        public Guid UserId { get; init; }
        public ResultMessageDto Message { get; init; } = new();
        public ResultAppUserPrivateDto User { get; init; } = new();
    }
}