namespace XenoTerra.DTOLayer.Dtos.PostDtos
{
    public class CreatePostDto
    {
        public required string Caption { get; set; }
        public required string Path { get; set; }
        public bool IsVideo { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}