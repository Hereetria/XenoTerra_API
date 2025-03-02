

namespace XenoTerra.DTOLayer.Dtos.ReactionDtos
{
    public class CreateReactionDto
    {
        public string Payload { get; set; }
        public Guid MessageId { get; set; }
        public Guid UserId { get; set; }
    }
}