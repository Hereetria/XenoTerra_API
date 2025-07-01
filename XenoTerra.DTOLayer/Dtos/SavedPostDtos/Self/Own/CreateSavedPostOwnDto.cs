namespace XenoTerra.DTOLayer.Dtos.SavedPostDtos.Self.Own
{
    public class CreateSavedPostOwnDto
    {
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
        public DateTime SavedAt { get; set; }
    }
}
