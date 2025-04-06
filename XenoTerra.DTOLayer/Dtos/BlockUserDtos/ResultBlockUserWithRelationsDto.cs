

using HotChocolate;
using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DTOLayer.Dtos.BlockUserDtos
{
    public record class ResultBlockUserWithRelationsDto(
        Guid BlockUserId,
        Guid BlockingUserId,
        Guid BlockedUserId,
        DateTime BlockedAt,
        ResultUserDto BlockingUser,
        ResultUserDto BlockedUser);
}