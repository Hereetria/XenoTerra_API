using XenoTerra.DTOLayer.Dtos.AppUserDtos;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.CommentLikeDtos.Admin;
using XenoTerra.DTOLayer.Dtos.PostDtos.Admin;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DTOLayer.Dtos.CommentDtos.Admin
{
    public class ResultCommentWithRelationsAdminDto
    {
        public Guid CommentId { get; init; }
        public string Content { get; init; } = string.Empty;
        public Guid PostId { get; init; }
        public Guid UserId { get; init; }
        public DateTime CommentedAt { get; init; }
        public Guid? ParentCommentId { get; init; }
        public ResultAppUserAdminDto User { get; set; } = new();
        public ResultPostAdminDto Post { get; set; } = new();
        public ICollection<ResultCommentLikeAdminDto> CommentLikes { get; set; } = [];
        public ResultCommentAdminDto? ParentComment { get; set; }
        public ICollection<ResultCommentAdminDto> Replies { get; set; } = [];
    }
}