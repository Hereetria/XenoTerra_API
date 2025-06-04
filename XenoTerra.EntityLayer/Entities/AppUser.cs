using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.EntityLayer.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FullName { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public string ProfilePicture { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public int FollowersCount { get; set; }
        public int FollowingCount { get; set; }
        public bool IsVerified { get; set; }
        public DateTime LastActive { get; set; }


        public ICollection<BlockUser> BlockedUsers { get; set; } = [];

        public ICollection<BlockUser> BlockingUsers { get; set; } = [];
        public ICollection<Post> Posts { get; set; } = [];

        public ICollection<Follow> Followers { get; set; } = [];

        public ICollection<Follow> Followings { get; set; } = [];

        public ICollection<PostLike> PostLikes { get; set; } = [];

        public ICollection<Comment> Comments { get; set; } = [];

        public ICollection<Highlight> Highlights { get; set; } = [];

        public ICollection<Message> SentMessages { get; set; } = [];

        public ICollection<Message> ReceivedMessages { get; set; } = [];

        public ICollection<Notification> Notifications { get; set; } = [];

        public ICollection<Media> SentMedias { get; set; } = [];

        public ICollection<Media> ReceivedMedias { get; set; } = [];

        public ICollection<Story> Stories { get; set; } = [];

        public ICollection<SavedPost> SavedPosts { get; set; } = [];

        public ICollection<ReportComment> ReportComments { get; set; } = [];
        public ICollection<ReportPost> ReportPosts { get; set; } = [];

        public ICollection<ViewStory> ViewStories { get; set; } = [];

        public UserSetting UserSetting { get; set; } = null!;

        public ICollection<SearchHistoryUser> SearchedBy { get; set; } = [];

        public ICollection<RecentChats> RecentChats { get; set; } = [];

        public Note Note { get; set; } = null!;
        public ICollection<UserPostTag> TaggedPosts { get; set; } = [];
    }
}
