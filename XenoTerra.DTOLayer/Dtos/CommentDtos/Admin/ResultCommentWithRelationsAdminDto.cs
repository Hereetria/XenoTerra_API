using XenoTerra.DTOLayer.Dtos.AppUserDtos;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.CommentLikeAdminDtos.Admin;
using XenoTerra.DTOLayer.Dtos.PostAdminDtos.Admin;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DTOLayer.Dtos.CommentAdminDtos.Admin
{
    public class ResultCommentWithRelationsAdminDto
    {
        public Guid CommentId { get; init; }
        public string Content { get; init; } = string.Empty;
        public Guid PostId { get; init; }
        public Guid UserId { get; init; }
        public DateTime CommentedAt { get; init; }
        public Guid? ParentCommentId { get; init; }
        public ResultAppUserAdminDto User { get; init; } = new();
        public ResultPostAdminDto Post { get; init; } = new();
        public ICollection<ResultCommentLikeAdminDto> CommentLikes { get; init; } = [];
        public ResultCommentAdminDto? ParentComment { get; init; }
        public ICollection<ResultCommentAdminDto> Replies { get; init; } = [];
    }
}