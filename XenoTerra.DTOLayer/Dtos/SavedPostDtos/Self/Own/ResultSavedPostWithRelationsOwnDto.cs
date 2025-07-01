using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.PostDtos.Self.Own;

namespace XenoTerra.DTOLayer.Dtos.SavedPostDtos.Self.Own
{
    public class ResultSavedPostWithRelationsOwnDto
    {
        public Guid SavedPostId { get; init; }
        public Guid UserId { get; init; }
        public Guid PostId { get; init; }
        public DateTime SavedAt { get; init; }
        public ResultAppUserOwnDto User { get; set; } = new();
        public ResultPostOwnDto Post { get; set; } = new();
    }
}