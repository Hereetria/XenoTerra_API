using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.CommentLikeDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.PostDtos.Self.Own;

namespace XenoTerra.DTOLayer.Dtos.CommentDtos.Self.Own
{
    public class ResultCommentWithRelationsOwnDto
    {
        public Guid CommentId { get; init; }
        public string Content { get; init; } = string.Empty;
        public Guid PostId { get; init; }
        public Guid UserId { get; init; }
        public DateTime CommentedAt { get; init; }
        public Guid? ParentCommentId { get; init; }
        public ResultAppUserOwnDto User { get; set; } = new();
        public ResultPostOwnDto Post { get; set; } = new();
        public ICollection<ResultCommentLikeOwnDto> CommentLikes { get; set; } = [];
        public ResultCommentOwnDto? ParentComment { get; set; }
        public ICollection<ResultCommentOwnDto> Replies { get; set; } = [];
    }
}