using XenoTerra.DTOLayer.Dtos.AppUserDtos;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.CommentAdminDtos.Admin;

namespace XenoTerra.DTOLayer.Dtos.CommentLikeAdminDtos.Admin
{
    public class ResultCommentLikeWithRelationsAdminDto
    {
        public Guid CommentLikeId { get; init; }
        public Guid CommentId { get; init; }
        public Guid UserId { get; init; }
        public DateTime LikedAt { get; init; }
        public ResultAppUserAdminDto User { get; set; } = new();
        public ResultCommentAdminDto Comment { get; set; } = new();
    }
}