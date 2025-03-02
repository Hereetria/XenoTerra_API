

namespace XenoTerra.DTOLayer.Dtos.FollowDtos
{
    public class ResultFollowByIdDto
    {
        public Guid FollowId { get; set; }
        public Guid FollowerId { get; set; }
        public Guid FollowingId { get; set; }
        public DateTime FollowedAt { get; set; }
    }
}