

namespace XenoTerra.DTOLayer.Dtos.ReactionDtos
{
    public class ResultReactionByIdDto
    {
        public Guid ReactionId { get; set; }
        public string Payload { get; set; }
        public Guid MessageId { get; set; }
        public Guid UserId { get; set; }
    }
}