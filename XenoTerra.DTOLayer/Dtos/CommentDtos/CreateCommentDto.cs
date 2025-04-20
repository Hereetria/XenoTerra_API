

using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.CommentDtos
{
    public class CreateCommentDto
    {
        public string Content { get; set; } = string.Empty;
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CommentedAt { get; set; }
    }
}