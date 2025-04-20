

using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.MediaDtos
{
    public class CreateMediaDto
    {
        public string PhotoUrl { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public DateTime UploadedAt { get; set; }
    }
}