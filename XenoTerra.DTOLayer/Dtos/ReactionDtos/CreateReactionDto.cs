

using XenoTerra.DTOLayer.Dtos.MessageDtos;
using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.ReactionDtos
{
    public class CreateReactionDto
    {
        public string Payload { get; set; }
        public Guid MessageId { get; set; }
        public Guid UserId { get; set; }

        public ResultMessageByIdDto Message { get; set; }
        public ResultUserByIdDto User { get; set; }
    }
}