

namespace XenoTerra.DTOLayer.Dtos.SavedPostDtos
{
    public class ResultSavedPostDto
    {
        public Guid SavedPostId { get; set; }
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
        public DateTime SavedAt { get; set; }
    }
}