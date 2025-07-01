using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.StoryDtos.Self.Own;

namespace XenoTerra.DTOLayer.Dtos.StoryLikeDtos.Self.Own
{
    public class ResultStoryLikeWithRelationsOwnDto
    {
        public Guid StoryLikeId { get; init; }
        public Guid StoryId { get; init; }
        public Guid UserId { get; init; }
        public DateTime LikedAt { get; init; }

        public ResultStoryOwnDto Story { get; set; } = new();
        public ResultAppUserOwnDto User { get; set; } = new();
    }
}