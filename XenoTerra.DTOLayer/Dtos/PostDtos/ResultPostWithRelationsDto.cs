

using XenoTerra.DTOLayer.Dtos.AppUserDtos;
using XenoTerra.DTOLayer.Dtos.CommentDtos;
using XenoTerra.DTOLayer.Dtos.PostLikeDtos;
using XenoTerra.DTOLayer.Dtos.SavedPostDtos;

namespace XenoTerra.DTOLayer.Dtos.PostDtos
{
    public record class ResultPostWithRelationsDto
    {
        public Guid PostId { get; init; }
        public string Caption { get; init; } = string.Empty;
        public string Path { get; init; } = string.Empty;
        public bool IsVideo { get; init; }
        public string? Location { get; init; } = string.Empty;
        public Guid UserId { get; init; }
        public DateTime CreatedAt { get; init; }
        public ResultAppUserPrivateDto? User { get; init; }
        public ICollection<ResultPostLikeDto> Likes { get; init; } = [];
        public ICollection<ResultCommentDto> Comments { get; init; } = [];
        public ICollection<ResultSavedPostDto> SavedPosts { get; init; } = [];
        public ICollection<ResultAppUserPrivateDto> TaggedUsers { get; init; } = [];
    }
}