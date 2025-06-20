namespace XenoTerra.DTOLayer.Dtos.SavedPostAdminDtos.Self.Own
{
    public class ResultSavedPostOwnDto
    {
        public Guid SavedPostId { get; init; }
        public Guid UserId { get; init; }
        public Guid PostId { get; init; }
        public DateTime SavedAt { get; init; }
    }
}