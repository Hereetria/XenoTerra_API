

using XenoTerra.DTOLayer.Dtos.CommentDtos;

namespace XenoTerra.DTOLayer.Dtos.CommentLikeDtos
{
    public class UpdateCommentLikeDto
    {
        public Guid CommentLikeId { get; set; }
        public Guid? CommentId { get; set; }
        public Guid? UserId { get; set; }
    }
}