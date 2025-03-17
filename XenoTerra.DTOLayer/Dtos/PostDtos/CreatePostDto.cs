namespace XenoTerra.DTOLayer.Dtos.PostDtos
{
    public class CreatePostDto
    {
        public string Caption { get; set; }
        public string Path { get; set; }
        public bool IsVideo { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}