namespace XenoTerra.DTOLayer.Dtos.FollowDtos.Admin
{
    public class UpdateFollowAdminDto
    {
        public Guid FollowId { get; set; }
        public Guid? FollowerId { get; set; }
        public bool? IsPending { get; set; }
        public Guid? FollowingId { get; set; }
    }
}