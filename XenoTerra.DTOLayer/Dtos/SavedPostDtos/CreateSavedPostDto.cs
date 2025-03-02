

namespace XenoTerra.DTOLayer.Dtos.SavedPostDtos
{
    public class CreateSavedPostDto
    {
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
        public DateTime SavedAt { get; set; }
    }
}