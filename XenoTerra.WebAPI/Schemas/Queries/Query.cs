using XenoTerra.BussinessLogicLayer.Services.BlockUserServices;
using XenoTerra.BussinessLogicLayer.Services.CommentServices;
using XenoTerra.BussinessLogicLayer.Services.FollowServices;
using XenoTerra.BussinessLogicLayer.Services.HighlightServices;
using XenoTerra.BussinessLogicLayer.Services.LikeServices;
using XenoTerra.BussinessLogicLayer.Services.MediaServices;
using XenoTerra.BussinessLogicLayer.Services.MessageServices;
using XenoTerra.BussinessLogicLayer.Services.NoteServices;
using XenoTerra.BussinessLogicLayer.Services.NotificationServices;
using XenoTerra.BussinessLogicLayer.Services.PostServices;
using XenoTerra.BussinessLogicLayer.Services.PostTagServices;
using XenoTerra.BussinessLogicLayer.Services.ReactionServices;
using XenoTerra.BussinessLogicLayer.Services.RecentChatsServices;
using XenoTerra.BussinessLogicLayer.Services.ReportCommentServices;
using XenoTerra.BussinessLogicLayer.Services.RoleServices;
using XenoTerra.BussinessLogicLayer.Services.SavedPostServices;
using XenoTerra.BussinessLogicLayer.Services.SearchHistoryServices;
using XenoTerra.BussinessLogicLayer.Services.SearchHistoryUserServices;
using XenoTerra.BussinessLogicLayer.Services.StoryServices;
using XenoTerra.BussinessLogicLayer.Services.UserServices;
using XenoTerra.BussinessLogicLayer.Services.UserSettingServices;
using XenoTerra.BussinessLogicLayer.Services.ViewStoryServices;
using XenoTerra.WebAPI.Schemas.Queries.BlockUser;
using XenoTerra.WebAPI.Schemas.Queries.Comment;
using XenoTerra.WebAPI.Schemas.Queries.Follow;
using XenoTerra.WebAPI.Schemas.Queries.Highlight;
using XenoTerra.WebAPI.Schemas.Queries.Like;
using XenoTerra.WebAPI.Schemas.Queries.Media;
using XenoTerra.WebAPI.Schemas.Queries.Message;
using XenoTerra.WebAPI.Schemas.Queries.Note;
using XenoTerra.WebAPI.Schemas.Queries.Notification;
using XenoTerra.WebAPI.Schemas.Queries.Post;
using XenoTerra.WebAPI.Schemas.Queries.PostTag;
using XenoTerra.WebAPI.Schemas.Queries.Reaction;
using XenoTerra.WebAPI.Schemas.Queries.RecentChats;
using XenoTerra.WebAPI.Schemas.Queries.ReportComment;
using XenoTerra.WebAPI.Schemas.Queries.Role;
using XenoTerra.WebAPI.Schemas.Queries.SavedPost;
using XenoTerra.WebAPI.Schemas.Queries.SearchHistory;
using XenoTerra.WebAPI.Schemas.Queries.SearchHistoryUser;
using XenoTerra.WebAPI.Schemas.Queries.Story;
using XenoTerra.WebAPI.Schemas.Queries.User;
using XenoTerra.WebAPI.Schemas.Queries.UserSetting;
using XenoTerra.WebAPI.Schemas.Queries.ViewStory;

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
        public PostTagQuery PostTags { get; }
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
            PostTags = new PostTagQuery();
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
