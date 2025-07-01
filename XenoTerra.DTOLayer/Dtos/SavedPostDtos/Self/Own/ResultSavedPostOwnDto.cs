namespace XenoTerra.DTOLayer.Dtos.SavedPostDtos.Self.Own
{
    public class ResultSavedPostOwnDto
    {
        public Guid SavedPostId { get; init; }
        public Guid UserId { get; init; }
        public Guid PostId { get; init; }
        public DateTime SavedAt { get; init; }
    }
}