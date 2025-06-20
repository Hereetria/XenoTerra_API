using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.EntityLayer.Entities
{
    public class Follow
    {
        public Guid FollowId { get; set; }

        public Guid FollowerId { get; set; }
        public AppUser Follower { get; set; } = null!;

        public Guid FollowingId { get; set; }
        public AppUser Following { get; set; } = null!;
        public bool IsPending { get; set; }

        public DateTime FollowedAt { get; set; }
    }
}
