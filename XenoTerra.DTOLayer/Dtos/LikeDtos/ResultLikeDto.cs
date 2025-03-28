using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.LikeDtos
{
    public record ResultLikeDto(
        Guid LikeId,
        Guid PostId,
        Guid UserId,
        DateTime LikedAt
    );
}
