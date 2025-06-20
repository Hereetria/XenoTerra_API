
namespace XenoTerra.DTOLayer.Dtos.PostLikeAdminDtos.Admin
{
    public class CreatePostLikeAdminDto
    {
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public DateTime LikedAt { get; set; }
    }
}