using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.EntityLayer.Entities
{
    public class StoryLike
    {
        public Guid StoryLikeId { get; set; }

        public Guid StoryId { get; set; }
        public Story Story { get; set; } = null!;

        public Guid UserId { get; set; }
        public AppUser User { get; set; } = null!;

        public DateTime LikedAt { get; set; }
    }
}
