

using XenoTerra.DTOLayer.Dtos.CommentDtos;
using XenoTerra.DTOLayer.Dtos.LikeDtos;
using XenoTerra.DTOLayer.Dtos.PostTagDtos;
using XenoTerra.DTOLayer.Dtos.SavedPostDtos;
using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.PostDtos
{
    public class CreatePostDto
    {
        public string Caption { get; set; }
        public string Path { get; set; }
        public bool IsVideo { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }

        public ResultUserByIdDto User { get; set; }
        public ICollection<ResultLikeByIdDto> Likes { get; set; }
        public ICollection<ResultCommentByIdDto> Comments { get; set; }
        public ICollection<ResultSavedPostByIdDto> SavedPosts { get; set; }
        public ICollection<ResultPostTagByIdDto> TaggedUsers { get; set; }
    }
}