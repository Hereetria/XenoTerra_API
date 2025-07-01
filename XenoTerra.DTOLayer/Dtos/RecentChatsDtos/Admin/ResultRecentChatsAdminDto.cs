using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.RecentChatsDtos.Admin
{
    public class ResultRecentChatsAdminDto
    {
        public Guid RecentChatsId { get; init; }
        public string LastMessage { get; init; } = string.Empty;
        public Guid UserId { get; init; }
        public DateTime LastMessageAt { get; init; }
    }
}
