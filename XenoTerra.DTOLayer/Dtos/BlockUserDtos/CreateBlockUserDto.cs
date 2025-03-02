

namespace XenoTerra.DTOLayer.Dtos.BlockUserDtos
{
    public class CreateBlockUserDto
    {
        public Guid BlockingUserId { get; set; }
        public Guid BlockedUserId { get; set; }
        public DateTime BlockedAt { get; set; }
    }
}