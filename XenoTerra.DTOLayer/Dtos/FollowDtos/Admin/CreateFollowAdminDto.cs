namespace XenoTerra.DTOLayer.Dtos.FollowDtos.Admin
{
    public class CreateFollowAdminDto
    {
        public Guid FollowerId { get; set; }
        public Guid FollowingId { get; set; }
        public bool IsPending { get; set; }
        public DateTime FollowedAt { get; set; }
    }
}