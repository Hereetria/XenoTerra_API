using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.BlockUserDtos
{
    public record ResultBlockUserDto(
        Guid BlockUserId,
        Guid BlockingUserId,
        Guid BlockedUserId,
        DateTime BlockedAt
    );
}
