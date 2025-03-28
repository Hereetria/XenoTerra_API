

using XenoTerra.DTOLayer.Dtos.MessageDtos;
using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.ReactionDtos
{
    public record ResultReactionWithRelationsDto(
        Guid ReactionId,
        string Payload,
        Guid MessageId,
        Guid UserId
    )
    {
        public ResultMessageDto? Message { get; set; }
        public ResultUserDto? User { get; set; }
    }
}