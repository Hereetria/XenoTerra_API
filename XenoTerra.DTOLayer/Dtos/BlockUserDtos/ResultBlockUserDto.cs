

using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.BlockUserDtos
{
    public class ResultBlockUserDto
    {
        public Guid BlockUserId { get; set; }
        public Guid BlockingUserId { get; set; }
        public Guid BlockedUserId { get; set; }
        public DateTime BlockedAt { get; set; }

        public ResultUserByIdDto BlockingUser { get; set; }
        public ResultUserByIdDto BlockedUser { get; set; }
    }
}