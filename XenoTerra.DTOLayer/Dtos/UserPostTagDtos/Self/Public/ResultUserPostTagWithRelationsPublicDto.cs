using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Public;
using XenoTerra.DTOLayer.Dtos.PostDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.PostDtos.Self.Public;

namespace XenoTerra.DTOLayer.Dtos.UserPostTagDtos.Self.Public
{
    public class ResultUserPostTagWithRelationsPublicDto
    {
        public Guid PostId { get; init; }
        public Guid UserId { get; init; }
        public ResultPostPublicDto Post { get; set; } = new();
        public ResultAppUserPublicDto User { get; set; } = new();
    }
}