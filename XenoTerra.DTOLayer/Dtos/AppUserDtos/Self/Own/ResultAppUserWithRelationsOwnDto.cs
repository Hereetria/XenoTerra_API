using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Own
{
    public class ResultAppUserWithRelationsOwnDto
    {
        public Guid Id { get; init; }
        public string UserName { get; init; } = string.Empty;
        public string Password { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public string FullName { get; init; } = string.Empty;
        public string Bio { get; init; } = string.Empty;
        public string ProfilePicture { get; init; } = string.Empty;
        public string Website { get; init; } = string.Empty;
        public DateTime BirthDate { get; init; }
        public int FollowersCount { get; init; }
        public int FollowingCount { get; init; }
        public bool IsVerified { get; init; }
        public DateTime LastActive { get; init; }


        public ICollection<BlockUser> BlockingUsers { get; set; } = [];
        public ICollection<Post> Posts { get; set; } = [];

        public ICollection<Follow> Followers { get; set; } = [];

        public ICollection<Follow> Followings { get; set; } = [];

        public ICollection<PostLike> PostLikes { get; set; } = [];
        public ICollection<StoryLike> StoryLikes { get; set; } = [];

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
        public ICollection<ReportStory> ReportStories { get; set; } = [];

        public ICollection<ViewStory> ViewStories { get; set; } = [];

        public UserSetting UserSetting { get; set; } = null!;

        public ICollection<SearchHistory> PerformedSearches { get; set; } = [];
        public ICollection<SearchHistoryUser> WasSearchedBy { get; set; } = [];

        public ICollection<RecentChats> RecentChats { get; set; } = [];

        public Note Note { get; set; } = null!;
        public ICollection<UserPostTag> TaggedPosts { get; set; } = [];
    }
}