

namespace XenoTerra.DTOLayer.Dtos.SavedPostDtos
{
    public class ResultSavedPostByIdDto
    {
        public Guid SavedPostId { get; set; }
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
        public DateTime SavedAt { get; set; }
    }
}