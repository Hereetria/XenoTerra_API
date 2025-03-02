

namespace XenoTerra.DTOLayer.Dtos.ReactionDtos
{
    public class ResultReactionDto
    {
        public Guid ReactionId { get; set; }
        public string Payload { get; set; }
        public Guid MessageId { get; set; }
        public Guid UserId { get; set; }
    }
}