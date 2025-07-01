namespace XenoTerra.DTOLayer.Dtos.FollowDtos.Self.Own
{
    public class CreateFollowOwnDto
    {
        public Guid FollowerId { get; set; }
        public Guid FollowingId { get; set; }
        public bool IsPending { get; set; }
        public DateTime FollowedAt { get; set; }
    }
}
