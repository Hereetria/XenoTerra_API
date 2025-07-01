using XenoTerra.DTOLayer.Dtos.AppUserDtos;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.PostDtos.Admin;

namespace XenoTerra.DTOLayer.Dtos.PostLikeDtos.Admin
{
    public class ResultPostLikeWithRelationsAdminDto
    {
        public Guid PostLikeId { get; init; }
        public Guid PostId { get; init; }
        public Guid UserId { get; init; }
        public DateTime LikedAt { get; init; }
        public ResultAppUserAdminDto User { get; set; } = new();
        public ResultPostAdminDto Post { get; set; } = new();
    }
}