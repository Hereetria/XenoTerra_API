

namespace XenoTerra.DTOLayer.Dtos.SavedPostDtos
{
    public class UpdateSavedPostDto
    {
        public Guid SavedPostId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? PostId { get; set; }
    }
}