using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.EntityLayer.Entities
{
    public class Notification
    {
        public Guid NotificationId { get; set; }

        public Guid UserId { get; set; }
        public AppUser User { get; set; } = null!;

        public Guid Message { get; set; }
        public string? Image { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
