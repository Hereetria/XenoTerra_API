using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.CommentLikeAdminDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.PostAdminDtos.Self.Own;

namespace XenoTerra.DTOLayer.Dtos.CommentAdminDtos.Self.Own
{
    public class ResultCommentWithRelationsOwnDto
    {
        public Guid CommentId { get; init; }
        public string Content { get; init; } = string.Empty;
        public Guid PostId { get; init; }
        public Guid UserId { get; init; }
        public DateTime CommentedAt { get; init; }
        public Guid? ParentCommentId { get; init; }
        public ResultAppUserOwnDto User { get; init; } = new();
        public ResultPostOwnDto Post { get; init; } = new();
        public ICollection<ResultCommentLikeOwnDto> CommentLikes { get; init; } = [];
        public ResultCommentOwnDto? ParentComment { get; init; }
        public ICollection<ResultCommentOwnDto> Replies { get; init; } = [];
    }
}