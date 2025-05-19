

using XenoTerra.DTOLayer.Dtos.CommentDtos;
using XenoTerra.DTOLayer.Dtos.LikeDtos;
using XenoTerra.DTOLayer.Dtos.SavedPostDtos;
using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.PostDtos
{
    public record class ResultPostWithRelationsDto
    {
        public Guid PostId { get; init; }
        public string Caption { get; init; } = string.Empty;
        public string Path { get; init; } = string.Empty;
        public bool IsVideo { get; init; }
        public Guid UserId { get; init; }
        public DateTime CreatedAt { get; init; }
        public ResultUserPrivateDto? User { get; init; }
        public ICollection<ResultLikeDto> Likes { get; init; } = [];
        public ICollection<ResultCommentDto> Comments { get; init; } = [];
        public ICollection<ResultSavedPostDto> SavedPosts { get; init; } = [];
        public ICollection<ResultUserPrivateDto> TaggedUsers { get; init; } = [];
    }
}