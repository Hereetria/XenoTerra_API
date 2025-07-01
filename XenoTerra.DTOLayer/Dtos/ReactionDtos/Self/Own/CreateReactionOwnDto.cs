namespace XenoTerra.DTOLayer.Dtos.ReactionDtos.Self.Own
{
    public class CreateReactionOwnDto
    {
        public string Payload { get; set; } = string.Empty;
        public Guid MessageId { get; set; }
        public Guid UserId { get; set; }
    }
}
