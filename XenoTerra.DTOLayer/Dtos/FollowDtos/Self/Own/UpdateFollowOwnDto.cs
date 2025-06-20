namespace XenoTerra.DTOLayer.Dtos.FollowAdminDtos.Self.Own
{
    public class UpdateFollowOwnDto
    {
        public Guid FollowId { get; set; }
        public Guid? FollowerId { get; set; }
        public bool? IsPending { get; set; }
    }
}
