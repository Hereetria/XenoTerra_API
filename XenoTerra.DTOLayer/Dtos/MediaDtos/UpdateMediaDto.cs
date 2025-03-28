

using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.MediaDtos
{
    public class UpdateMediaDto
    {
        public Guid MediaId { get; set; }
        public required string PhotoUrl { get; set; }
        public Guid UserId { get; set; }
        public DateTime UploadedAt { get; set; }
    }
}