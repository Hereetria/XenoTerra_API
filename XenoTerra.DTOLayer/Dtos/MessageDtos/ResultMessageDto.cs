using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.MessageDtos
{
    public record ResultMessageDto(
        Guid MessageId,
        string Content,
        Guid SenderId,
        Guid ReceiverId,
        string Header,
        DateTime SentAt
    );
}
