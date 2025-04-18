namespace XenoTerra.DTOLayer.Dtos.PostDtos
{
    public class UpdatePostDto
    {
        public Guid PostId { get; set; }
        public required string Caption { get; set; }
        public required string Path { get; set; }
        public bool IsVideo { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}