using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.EntityLayer.Entities
{
    public class Post
    {
        public Guid PostId { get; set; }
        public string Caption { get; set; }
        public string Path { get; set; }
        public bool isVideo { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public ICollection<Like> Likes { get; set; } = new List<Like>();
        
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public ICollection<SavedPost> SavedPosts { get; set; } = new List<SavedPost>();

        public ICollection<UserPostTag> TaggedUsers { get; set; } = new List<UserPostTag>();
        public DateTime CreatedAt { get; set; }
    }
}
