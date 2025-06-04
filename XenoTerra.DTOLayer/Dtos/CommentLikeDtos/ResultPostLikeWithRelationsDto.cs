

using XenoTerra.DTOLayer.Dtos.AppUserDtos;
using XenoTerra.DTOLayer.Dtos.CommentDtos;

namespace XenoTerra.DTOLayer.Dtos.CommentLikeDtos
{
    public record class ResultCommentLikeWithRelationsDto
    {
        public Guid CommentLikeId { get; init; }
        public Guid CommentId { get; init; }
        public Guid UserId { get; init; }
        public DateTime LikedAt { get; init; }
        public ResultAppUserPrivateDto User { get; init; } = new();
        public ResultCommentDto Comment { get; init; } = new();
    }
}