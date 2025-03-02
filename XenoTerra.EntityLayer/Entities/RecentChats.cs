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
        public string LastMessage { get; set; }

        public Guid UserId { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();

        public DateTime LastMessageAt { get; set; }
    }
}
