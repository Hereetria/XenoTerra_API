

namespace XenoTerra.DTOLayer.Dtos.MediaDtos
{
    public class ResultMediaDto
    {
        public Guid MediaId { get; set; }
        public string PhotoUrl { get; set; }
        public Guid UserId { get; set; }
        public DateTime UploadedAt { get; set; }
    }
}