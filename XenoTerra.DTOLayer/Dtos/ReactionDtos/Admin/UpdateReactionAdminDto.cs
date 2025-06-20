
namespace XenoTerra.DTOLayer.Dtos.ReactionAdminDtos.Admin
{
    public class UpdateReactionAdminDto
    {
        public Guid ReactionId { get; set; }
        public string? Payload { get; set; } = string.Empty;
        public Guid? MessageId { get; set; }
        public Guid? UserId { get; set; }
    }
}