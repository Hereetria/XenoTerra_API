

using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.FollowDtos
{
    public class ResultFollowDto
    {
        public Guid FollowId { get; set; }
        public Guid FollowerId { get; set; }
        public Guid FollowingId { get; set; }
        public DateTime FollowedAt { get; set; }

        public ResultUserByIdDto Follower { get; set; }
        public ResultUserByIdDto Following { get; set; }
    }
}