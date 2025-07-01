namespace XenoTerra.DTOLayer.Dtos.FollowDtos.Self.Own
{
    public class UpdateFollowOwnDto
    {
        public Guid FollowId { get; set; }
        public Guid? FollowerId { get; set; }
        public bool? IsPending { get; set; }
    }
}
