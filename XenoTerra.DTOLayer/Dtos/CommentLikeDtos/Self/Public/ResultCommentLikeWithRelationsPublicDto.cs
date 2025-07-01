using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Public;
using XenoTerra.DTOLayer.Dtos.CommentDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.CommentDtos.Self.Public;

namespace XenoTerra.DTOLayer.Dtos.CommentLikeDtos.Self.Public
{
    public class ResultCommentLikeWithRelationsPublicDto
    {
        public Guid CommentLikeId { get; init; }
        public Guid CommentId { get; init; }
        public Guid UserId { get; init; }
        public DateTime LikedAt { get; init; }
        public ResultAppUserPublicDto User { get; set; } = new();
        public ResultCommentPublicDto Comment { get; set; } = new();
    }
}