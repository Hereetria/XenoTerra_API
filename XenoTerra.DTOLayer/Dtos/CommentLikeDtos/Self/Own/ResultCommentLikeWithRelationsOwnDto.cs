using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.CommentDtos.Self.Own;

namespace XenoTerra.DTOLayer.Dtos.CommentLikeDtos.Self.Own
{
    public class ResultCommentLikeWithRelationsOwnDto
    {
        public Guid CommentLikeId { get; init; }
        public Guid CommentId { get; init; }
        public Guid UserId { get; init; }
        public DateTime LikedAt { get; init; }
        public ResultAppUserOwnDto User { get; set; } = new();
        public ResultCommentOwnDto Comment { get; set; } = new();
    }
}