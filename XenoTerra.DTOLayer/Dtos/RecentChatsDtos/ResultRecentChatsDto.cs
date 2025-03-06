using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.RecentChatsDtos
{
    public class ResultRecentChatsDto
    {
        public Guid RecentChatsId { get; set; }
        public string LastMessage { get; set; }
        public Guid UserId { get; set; }
        public DateTime LastMessageAt { get; set; }
    }
}
