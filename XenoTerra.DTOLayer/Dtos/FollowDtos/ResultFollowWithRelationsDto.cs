

using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.FollowDtos
{
    public class ResultFollowWithRelationsDto
    {
        public Guid FollowId { get; set; }
        public Guid FollowerId { get; set; }
        public Guid FollowingId { get; set; }
        public DateTime FollowedAt { get; set; }

        public ResultUserDto Follower { get; set; }
        public ResultUserDto Following { get; set; }
    }
}