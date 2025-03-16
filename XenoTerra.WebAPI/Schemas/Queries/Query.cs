using XenoTerra.WebAPI.Schemas.Queries.BlockUserQueries;
using XenoTerra.WebAPI.Schemas.Queries.CommentQueries;
using XenoTerra.WebAPI.Schemas.Queries.FollowQueries;
using XenoTerra.WebAPI.Schemas.Queries.HighlightQueries;
using XenoTerra.WebAPI.Schemas.Queries.LikeQueries;
using XenoTerra.WebAPI.Schemas.Queries.MediaQueries;
using XenoTerra.WebAPI.Schemas.Queries.MessageQueries;
using XenoTerra.WebAPI.Schemas.Queries.NoteQueries;
using XenoTerra.WebAPI.Schemas.Queries.NotificationQueries;
using XenoTerra.WebAPI.Schemas.Queries.PostQueries;
using XenoTerra.WebAPI.Schemas.Queries.PostTagQueries;
using XenoTerra.WebAPI.Schemas.Queries.ReactionQueries;
using XenoTerra.WebAPI.Schemas.Queries.RecentChatsQueries;
using XenoTerra.WebAPI.Schemas.Queries.ReportCommentQueries;
using XenoTerra.WebAPI.Schemas.Queries.RoleQueries;
using XenoTerra.WebAPI.Schemas.Queries.SavedPostQueries;
using XenoTerra.WebAPI.Schemas.Queries.SearchHistoryQueries;
using XenoTerra.WebAPI.Schemas.Queries.SearchHistoryUserQueries;
using XenoTerra.WebAPI.Schemas.Queries.StoryQueries;
using XenoTerra.WebAPI.Schemas.Queries.UserQueries;
using XenoTerra.WebAPI.Schemas.Queries.UserSettingQueries;
using XenoTerra.WebAPI.Schemas.Queries.ViewStoryQueries;

namespace XenoTerra.WebAPI.Schemas.Queries
{
    public class Query
    {
        public BlockUserQuery BlockUsers { get; }
        public CommentQuery Comments { get; }
        public FollowQuery Follows { get; }
        public HighlightQuery Highlights { get; }
        public LikeQuery Likes { get; }
        public MediaQuery Media { get; }
        public MessageQuery Messages { get; }
        public NoteQuery Notes { get; }
        public NotificationQuery Notifications { get; }
        public PostQuery Posts { get; }
        public UserPostTagQuery PostTags { get; }
        public ReactionQuery Reactions { get; }
        public RecentChatsQuery RecentChats { get; }
        public ReportCommentQuery ReportComments { get; }
        public RoleQuery Roles { get; }
        public SavedPostQuery SavedPosts { get; }
        public SearchHistoryQuery SearchHistories { get; }
        public SearchHistoryUserQuery SearchHistoryUsers { get; }
        public StoryQuery Stories { get; }
        public UserQuery Users { get; }
        public UserSettingQuery UserSettings { get; }
        public ViewStoryQuery ViewStories { get; }

        public Query()
        {
            BlockUsers = new BlockUserQuery();
            Comments = new CommentQuery();
            Follows = new FollowQuery();
            Highlights = new HighlightQuery();
            Likes = new LikeQuery();
            Media = new MediaQuery();
            Messages = new MessageQuery();
            Notes = new NoteQuery();
            Notifications = new NotificationQuery();
            Posts = new PostQuery();
            PostTags = new UserPostTagQuery();
            Reactions = new ReactionQuery();
            RecentChats = new RecentChatsQuery();
            ReportComments = new ReportCommentQuery();
            Roles = new RoleQuery();
            SavedPosts = new SavedPostQuery();
            SearchHistories = new SearchHistoryQuery();
            SearchHistoryUsers = new SearchHistoryUserQuery();
            Stories = new StoryQuery();
            Users = new UserQuery();
            UserSettings = new UserSettingQuery();
            ViewStories = new ViewStoryQuery();
        }
    }
}
