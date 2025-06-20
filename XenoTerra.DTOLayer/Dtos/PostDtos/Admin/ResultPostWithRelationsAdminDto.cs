using XenoTerra.DTOLayer.Dtos.AppUserDtos;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.CommentAdminDtos.Admin;
using XenoTerra.DTOLayer.Dtos.PostLikeAdminDtos.Admin;
using XenoTerra.DTOLayer.Dtos.ReportPostAdminDtos.Admin;
using XenoTerra.DTOLayer.Dtos.SavedPostAdminDtos.Admin;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DTOLayer.Dtos.PostAdminDtos.Admin
{
    public class ResultPostWithRelationsAdminDto
    {
        public Guid PostId { get; init; }
        public string Caption { get; init; } = string.Empty;
        public string Path { get; init; } = string.Empty;
        public bool IsVideo { get; init; }
        public string? Location { get; init; } = string.Empty;
        public Guid UserId { get; init; }
        public DateTime CreatedAt { get; init; }
        public ResultAppUserAdminDto User { get; set; } = new();
        public ICollection<ResultPostLikeAdminDto> Likes { get; set; } = [];
        public ICollection<ResultCommentAdminDto> Comments { get; set; } = [];
        public ICollection<ResultSavedPostAdminDto> SavedPosts { get; set; } = [];
        public ICollection<ResultReportPostAdminDto> ReportPosts { get; set; } = [];
        public ICollection<ResultAppUserAdminDto> TaggedUsers { get; set; } = [];
    }
}