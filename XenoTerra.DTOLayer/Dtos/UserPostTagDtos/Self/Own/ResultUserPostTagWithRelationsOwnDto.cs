using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.PostDtos.Self.Own;

namespace XenoTerra.DTOLayer.Dtos.UserPostTagDtos.Self.Own
{
    public class ResultUserPostTagWithRelationsOwnDto
    {
        public Guid PostId { get; init; }
        public Guid UserId { get; init; }
        public ResultPostOwnDto Post { get; set; } = new();
        public ResultAppUserOwnDto User { get; set; } = new();
    }
}