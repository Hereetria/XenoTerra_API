

using XenoTerra.DTOLayer.Dtos.AppUserDtos;
using XenoTerra.DTOLayer.Dtos.CommentLikeDtos;
using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DTOLayer.Dtos.CommentDtos
{
    public record class ResultCommentWithRelationsDto
    {
        public Guid CommentId { get; init; }
        public string Content { get; init; } = string.Empty;
        public Guid PostId { get; init; }
        public Guid UserId { get; init; }
        public DateTime CommentedAt { get; init; }
        public ResultAppUserPrivateDto User { get; init; } = new();
        public ResultPostDto Post { get; init; } = new();
        public ICollection<ResultCommentLikeDto> CommentLikes { get; init; } = [];
        public Guid? ParentCommentId { get; init; }
        public ResultCommentDto? ParentComment { get; init; }
        public ICollection<ResultCommentDto> Replies { get; init; } = [];
    }
}