

using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.MediaDtos
{
    public class ResultMediaWithRelationsDto
    {
        public Guid MediaId { get; set; }
        public string PhotoUrl { get; set; }
        public Guid UserId { get; set; }
        public DateTime UploadedAt { get; set; }

        public ResultUserDto User { get; set; }
    }
}