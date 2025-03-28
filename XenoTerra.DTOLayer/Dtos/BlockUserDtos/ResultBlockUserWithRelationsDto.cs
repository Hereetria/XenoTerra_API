

using HotChocolate;
using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.BlockUserDtos
{
    public record ResultBlockUserWithRelationsDto(
        Guid BlockUserId,
        Guid BlockingUserId,
        Guid BlockedUserId,
        DateTime BlockedAt
    )
    {
        public ResultUserDto? BlockingUser { get; set; }
        public ResultUserDto? BlockedUser { get; set; }
    }
}