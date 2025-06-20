
namespace XenoTerra.DTOLayer.Dtos.PostLikeAdminDtos.Admin
{
    public class UpdatePostLikeAdminDto
    {
        public Guid PostLikeId { get; set; }
        public Guid? PostId { get; set; }
        public Guid? UserId { get; set; }
    }
}