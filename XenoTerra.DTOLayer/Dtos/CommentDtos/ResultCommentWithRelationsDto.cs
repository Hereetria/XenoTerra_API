

using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.CommentDtos
{
    public class ResultCommentWithRelationsDto
    {
        public Guid CommentId { get; set; }
        public string Content { get; set; }
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CommentedAt { get; set; }

        public ResultUserDto User { get; set; }
        public ResultPostDto Post { get; set; }
    }
}