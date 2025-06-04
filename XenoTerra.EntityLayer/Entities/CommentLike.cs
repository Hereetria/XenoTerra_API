using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.EntityLayer.Entities
{
    public class CommentLike
    {
        public Guid CommentLikeId { get; set; }

        public Guid CommentId { get; set; }
        public Comment Comment { get; set; } = null!;

        public Guid UserId { get; set; }
        public AppUser User { get; set; } = null!;

        public DateTime LikedAt { get; set; }
    }
}
