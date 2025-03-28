using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.FollowDtos
{
    public record ResultFollowDto(
        Guid FollowId,
        Guid FollowerId,
        Guid FollowingId,
        DateTime FollowedAt
    );
}
