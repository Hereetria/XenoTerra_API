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
        public string Caption { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public bool IsVideo { get; set; }
        public string? Location { get; set; } = string.Empty;

        public Guid UserId { get; set; }
        public AppUser User { get; set; } = null!;

        public ICollection<PostLike> Likes { get; set; } = [];
        
        public ICollection<Comment> Comments { get; set; } = [];

        public ICollection<SavedPost> SavedPosts { get; set; } = [];

        public ICollection<UserPostTag> TaggedUsers { get; set; } = [];
        public ICollection<ReportPost> ReportPosts { get; set; } = [];
        public DateTime CreatedAt { get; set; }
    }
}
