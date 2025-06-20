namespace XenoTerra.DTOLayer.Dtos.ReactionAdminDtos.Self.Own
{
    public class ResultReactionOwnDto
    {
        public Guid ReactionId { get; init; }
        public string Payload { get; init; } = string.Empty;
        public Guid MessageId { get; init; }
        public Guid UserId { get; init; }
    }
}