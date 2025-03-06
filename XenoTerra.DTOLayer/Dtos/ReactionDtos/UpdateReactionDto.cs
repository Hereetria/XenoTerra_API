

using XenoTerra.DTOLayer.Dtos.MessageDtos;
using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.ReactionDtos
{
    public class UpdateReactionDto
    {
        public Guid ReactionId { get; set; }
        public string Payload { get; set; }
        public Guid MessageId { get; set; }
        public Guid UserId { get; set; }
    }
}