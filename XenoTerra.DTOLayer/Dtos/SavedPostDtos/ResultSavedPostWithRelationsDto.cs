

namespace XenoTerra.DTOLayer.Dtos.SavedPostDtos
{
    public record class ResultSavedPostWithRelationsDto
    {
        public Guid SavedPostId { get; init; }
        public Guid UserId { get; init; }
        public Guid PostId { get; init; }
        public DateTime SavedAt { get; init; }
    }
}