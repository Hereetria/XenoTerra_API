using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Public;
using XenoTerra.DTOLayer.Dtos.CommentDtos.Self.Public;
using XenoTerra.DTOLayer.Dtos.CommentLikeDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.CommentLikeDtos.Self.Public;
using XenoTerra.DTOLayer.Dtos.PostDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.PostDtos.Self.Public;

namespace XenoTerra.DTOLayer.Dtos.CommentDtos.Self.Public
{
    public class ResultCommentWithRelationsPublicDto
    {
        public Guid CommentId { get; init; }
        public string Content { get; init; } = string.Empty;
        public Guid PostId { get; init; }
        public Guid UserId { get; init; }
        public DateTime CommentedAt { get; init; }
        public Guid? ParentCommentId { get; init; }

        public ResultAppUserPublicDto User { get; set; } = new();
        public ResultPostPublicDto Post { get; set; } = new();
        public ICollection<ResultCommentLikePublicDto> CommentLikes { get; set; } = [];
        public ResultCommentPublicDto? ParentComment { get; set; }
        public ICollection<ResultCommentPublicDto> Replies { get; set; } = [];
    }
}