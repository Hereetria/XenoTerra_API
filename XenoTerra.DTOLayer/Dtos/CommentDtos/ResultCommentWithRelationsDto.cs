

using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.CommentDtos
{
    public record ResultCommentWithRelationsDto(
        Guid CommentId,
        string Content,
        Guid PostId,
        Guid UserId,
        DateTime CommentedAt
    )
    {
        public ResultUserDto? User { get; set; }
        public ResultPostDto? Post { get; set; }
    }
}