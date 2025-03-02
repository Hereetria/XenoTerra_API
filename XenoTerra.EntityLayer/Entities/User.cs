using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.EntityLayer.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string FullName { get; set; }
        public string Bio { get; set; }
        public string ProfilePicture { get; set; }
        public string Website { get; set; }
        public DateTime BirthDate { get; set; }
        public int FollowersCount { get; set; }
        public int FollowingCount { get; set; }
        public bool IsVerified { get; set; }
        public DateTime LastActive { get; set; }

        public ICollection<Post> Posts { get; set; } = new List<Post>();

        public ICollection<Follow> Followers { get; set; } = new List<Follow>();

        public ICollection<Follow> Followings { get; set; } = new List<Follow>();

        public ICollection<Like> Likes { get; set; } = new List<Like>();

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public ICollection<Message> SentMessages { get; set; } = new List<Message>();

        public ICollection<Message> ReceivedMessages { get; set; } = new List<Message>();

        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();

        public ICollection<Media> Medias { get; set; } = new List<Media>();

        public ICollection<Story> Stories { get; set; } = new List<Story>();

        public ICollection<SavedPost> SavedPosts { get; set; } = new List<SavedPost>();

        public ICollection<ReportComment> ReportComments { get; set; } = new List<ReportComment>();

        public ICollection<ViewStory> ViewStories { get; set; } = new List<ViewStory>();

        public ICollection<UserSetting> UserSettings { get; set; } = new List<UserSetting>();

        public ICollection<SearchHistoryUser> SearchedBy { get; set; } = new List<SearchHistoryUser>();

        public ICollection<RecentChats> RecentChats { get; set; } = new List<RecentChats>();

        public Note Note { get; set; }

        public ICollection<Reaction> Reactions { get; set; } = new List<Reaction>();
        public ICollection<PostTag> TaggedPosts { get; set; } = new List<PostTag>();
    }
}
