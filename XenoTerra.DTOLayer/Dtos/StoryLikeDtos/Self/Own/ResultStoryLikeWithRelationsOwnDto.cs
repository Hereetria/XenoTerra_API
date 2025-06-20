using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.StoryAdminDtos.Self.Own;

namespace XenoTerra.DTOLayer.Dtos.StoryLikeAdminDtos.Self.Own
{
    public class ResultStoryLikeWithRelationsOwnDto
    {
        public Guid StoryLikeId { get; set; }
        public Guid StoryId { get; set; }
        public Guid UserId { get; set; }
        public DateTime LikedAt { get; set; }

        public ResultStoryOwnDto Story { get; set; } = new();
        public ResultAppUserOwnDto User { get; set; } = new();
    }
}