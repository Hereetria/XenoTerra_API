


namespace XenoTerra.DTOLayer.Dtos.FollowDtos
{
    public class UpdateFollowDto
    {
        public Guid FollowId { get; set; }
        public Guid? FollowerId { get; set; }
        public Guid? FollowingId { get; set; }
    }
}