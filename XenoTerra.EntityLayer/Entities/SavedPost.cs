using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.EntityLayer.Entities
{
    public class SavedPost
    {
        public Guid SavedPostId { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        public Guid PostId { get; set; }
        public Post Post { get; set; } = null!;

        public DateTime SavedAt { get; set; }
    }
}
