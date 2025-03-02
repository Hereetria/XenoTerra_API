

namespace XenoTerra.DTOLayer.Dtos.PostDtos
{
    public class ResultPostByIdDto
    {
        public Guid PostId { get; set; }
        public string Caption { get; set; }
        public string Path { get; set; }
        public bool isVideo { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}