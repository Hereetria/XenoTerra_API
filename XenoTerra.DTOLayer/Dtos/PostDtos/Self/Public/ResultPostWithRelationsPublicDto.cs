using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Public;
using XenoTerra.DTOLayer.Dtos.CommentDtos.Self.Public;
using XenoTerra.DTOLayer.Dtos.PostLikeDtos.Self.Public;

namespace XenoTerra.DTOLayer.Dtos.PostDtos.Self.Public
{
    public class ResultPostWithRelationsPublicDto
    {
        public Guid PostId { get; init; }
        public string Caption { get; init; } = string.Empty;
        public string Path { get; init; } = string.Empty;
        public bool IsVideo { get; init; }
        public string? Location { get; init; } = string.Empty;
        public Guid UserId { get; init; }
        public DateTime CreatedAt { get; init; }
        public ResultAppUserPublicDto User { get; set; } = new();
        public ICollection<ResultPostLikePublicDto> Likes { get; set; } = [];
        public ICollection<ResultCommentPublicDto> Comments { get; set; } = [];
        public ICollection<ResultAppUserPublicDto> TaggedUsers { get; set; } = [];
    }
}