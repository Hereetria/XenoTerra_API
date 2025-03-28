using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.UserDtos
{
    public record ResultUserDto(
        Guid Id,
        string UserName,
        string Password,
        string Email,
        string FullName,
        string Bio,
        string ProfilePicture,
        string Website,
        DateTime BirthDate,
        int FollowersCount,
        int FollowingCount,
        bool IsVerified,
        DateTime LastActive
    );
}
