namespace XenoTerra.DTOLayer.Dtos.FollowAdminDtos.Self.Own
{
    public class ResultFollowOwnDto
    {
        public Guid FollowId { get; init; }
        public Guid FollowerId { get; init; }
        public Guid FollowingId { get; init; }
        public bool IsPending { get; init; }
        public DateTime FollowedAt { get; init; }
    }
}