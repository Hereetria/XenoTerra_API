namespace XenoTerra.DTOLayer.Dtos.FollowAdminDtos.Self.Own
{
    public class CreateFollowOwnDto
    {
        public Guid FollowerId { get; set; }
        public Guid FollowingId { get; set; }
        public bool IsPending { get; set; }
        public DateTime FollowedAt { get; set; }
    }
}
