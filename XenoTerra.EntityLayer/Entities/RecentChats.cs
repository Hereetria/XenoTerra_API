using XenoTerra.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.EntityLayer.Entities
{
    public class RecentChats
    {
        public Guid RecentChatsId { get; set; }
        public string LastMessage { get; set; } = string.Empty;

        public Guid UserId { get; set; }
        public ICollection<AppUser> Users { get; set; } = [];

        public DateTime LastMessageAt { get; set; }
    }
}
