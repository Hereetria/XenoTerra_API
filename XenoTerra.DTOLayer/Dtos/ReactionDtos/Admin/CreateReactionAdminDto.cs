namespace XenoTerra.DTOLayer.Dtos.ReactionDtos.Admin
{
    public class CreateReactionAdminDto
    {
        public string Payload { get; set; } = string.Empty;
        public Guid MessageId { get; set; }
        public Guid UserId { get; set; }
    }
}