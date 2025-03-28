using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.RecentChatsDtos
{
    public record ResultRecentChatsDto(
        Guid RecentChatsId,
        string LastMessage,
        Guid UserId,
        DateTime LastMessageAt
    );
}
