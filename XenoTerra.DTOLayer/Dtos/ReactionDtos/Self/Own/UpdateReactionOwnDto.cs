namespace XenoTerra.DTOLayer.Dtos.ReactionDtos.Self.Own
{
    public class UpdateReactionOwnDto
    {
        public Guid ReactionId { get; set; }
        public string? Payload { get; set; } = string.Empty;
        public Guid? MessageId { get; set; }
    }
}
