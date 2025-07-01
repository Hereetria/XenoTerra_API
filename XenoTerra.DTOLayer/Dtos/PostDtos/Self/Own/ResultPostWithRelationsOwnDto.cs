using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.CommentDtos.Admin;
using XenoTerra.DTOLayer.Dtos.PostLikeDtos.Admin;

namespace XenoTerra.DTOLayer.Dtos.PostDtos.Self.Own
{
    public class ResultPostWithRelationsOwnDto
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
        public ICollection<ResultAppUserAdminDto> TaggedUsers { get; set; } = [];
    }
}