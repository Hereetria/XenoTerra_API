

using XenoTerra.DTOLayer.Dtos.MessageDtos;

namespace XenoTerra.DTOLayer.Dtos.ReactionDtos
{
    public class CreateReactionDto
    {
        public string Payload { get; set; } = string.Empty;
        public Guid MessageId { get; set; }
        public Guid UserId { get; set; }
    }
}