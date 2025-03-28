

using XenoTerra.DTOLayer.Dtos.CommentDtos;
using XenoTerra.DTOLayer.Dtos.LikeDtos;
using XenoTerra.DTOLayer.Dtos.SavedPostDtos;
using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.PostDtos
{
    public record ResultPostWithRelationsDto(
        Guid PostId,
        string Caption,
        string Path,
        bool IsVideo,
        Guid UserId,
        DateTime CreatedAt
    )
    {
        public ResultUserDto? User { get; set; }
        public ICollection<ResultLikeDto>? Likes { get; set; }
        public ICollection<ResultCommentDto>? Comments { get; set; }
        public ICollection<ResultSavedPostDto>? SavedPosts { get; set; }
        public ICollection<ResultUserDto>? TaggedUsers { get; set; }
    }
}