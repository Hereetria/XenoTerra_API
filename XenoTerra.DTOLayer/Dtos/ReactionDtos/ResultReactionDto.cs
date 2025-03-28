using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.ReactionDtos
{
    public record ResultReactionDto(
        Guid ReactionId,
        string Payload,
        Guid MessageId,
        Guid UserId
    );
}
