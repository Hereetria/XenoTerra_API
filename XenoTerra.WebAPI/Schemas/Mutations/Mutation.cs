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
using XenoTerra.WebAPI.Schemas.Mutations.BlockUser;
using XenoTerra.WebAPI.Schemas.Mutations.Comment;
using XenoTerra.WebAPI.Schemas.Mutations.Follow;
using XenoTerra.WebAPI.Schemas.Mutations.Highlight;
using XenoTerra.WebAPI.Schemas.Mutations.Like;
using XenoTerra.WebAPI.Schemas.Mutations.Media;
using XenoTerra.WebAPI.Schemas.Mutations.Message;
using XenoTerra.WebAPI.Schemas.Mutations.Note;
using XenoTerra.WebAPI.Schemas.Mutations.Notification;
using XenoTerra.WebAPI.Schemas.Mutations.Post;
using XenoTerra.WebAPI.Schemas.Mutations.PostTag;
using XenoTerra.WebAPI.Schemas.Mutations.Reaction;
using XenoTerra.WebAPI.Schemas.Mutations.RecentChats;
using XenoTerra.WebAPI.Schemas.Mutations.ReportComment;
using XenoTerra.WebAPI.Schemas.Mutations.Role;
using XenoTerra.WebAPI.Schemas.Mutations.SavedPost;
using XenoTerra.WebAPI.Schemas.Mutations.SearchHistory;
using XenoTerra.WebAPI.Schemas.Mutations.SearchHistoryUser;
using XenoTerra.WebAPI.Schemas.Mutations.Story;
using XenoTerra.WebAPI.Schemas.Mutations.User;
using XenoTerra.WebAPI.Schemas.Mutations.UserSetting;
using XenoTerra.WebAPI.Schemas.Mutations.ViewStory;

namespace XenoTerra.WebAPI.Schemas.Mutations
{
    public class Mutation
    {
        public BlockUserMutation BlockUsers { get; }
        public CommentMutation Comments { get; }
        public FollowMutation Follows { get; }
        public HighlightMutation Highlights { get; }
        public LikeMutation Likes { get; }
        public MediaMutation Media { get; }
        public MessageMutation Messages { get; }
        public NoteMutation Notes { get; }
        public NotificationMutation Notifications { get; }
        public PostMutation Posts { get; }
        public PostTagMutation PostTags { get; }
        public ReactionMutation Reactions { get; }
        public RecentChatsMutation RecentChats { get; }
        public ReportCommentMutation ReportComments { get; }
        public RoleMutation Roles { get; }
        public SavedPostMutation SavedPosts { get; }
        public SearchHistoryMutation SearchHistories { get; }
        public SearchHistoryUserMutation SearchHistoryUsers { get; }
        public StoryMutation Stories { get; }
        public UserMutation Users { get; }
        public UserSettingMutation UserSettings { get; }
        public ViewStoryMutation ViewStories { get; }

        public Mutation()
        {
            BlockUsers = new BlockUserMutation();
            Comments = new CommentMutation();
            Follows = new FollowMutation();
            Highlights = new HighlightMutation();
            Likes = new LikeMutation();
            Media = new MediaMutation();
            Messages = new MessageMutation();
            Notes = new NoteMutation();
            Notifications = new NotificationMutation();
            Posts = new PostMutation();
            PostTags = new PostTagMutation();
            Reactions = new ReactionMutation();
            RecentChats = new RecentChatsMutation();
            ReportComments = new ReportCommentMutation();
            Roles = new RoleMutation();
            SavedPosts = new SavedPostMutation();
            SearchHistories = new SearchHistoryMutation();
            SearchHistoryUsers = new SearchHistoryUserMutation();
            Stories = new StoryMutation();
            Users = new UserMutation();
            UserSettings = new UserSettingMutation();
            ViewStories = new ViewStoryMutation();
        }
    }
}
