using AutoMapper;
using System.Net.Security;
using XenoTerra.WebAPI.GraphQL.Auth;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Mutations;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.GraphQL.Schemas
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
        public ReactionMutation Reactions { get; }
        public RecentChatsMutation RecentChats { get; }
        public ReportCommentMutation ReportComments { get; }
        public RoleMutation Roles { get; }
        public SavedPostMutation SavedPosts { get; }
        public SearchHistoryMutation SearchHistories { get; }
        public SearchHistoryUserMutation SearchHistoryUsers { get; }
        public StoryHighlightMutation StoryHighlights { get; }
        public StoryMutation Stories { get; }
        public UserPostTagMutation UserPostTags { get; }
        public UserMutation Users { get; }
        public UserSettingMutation UserSettings { get; }
        public ViewStoryMutation ViewStories { get; }
        public LoginMutation Logins { get; }
        public RegisterMutation Registers { get; }


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
            Reactions = new ReactionMutation();
            RecentChats = new RecentChatsMutation();
            ReportComments = new ReportCommentMutation();
            Roles = new RoleMutation();
            SavedPosts = new SavedPostMutation();
            SearchHistories = new SearchHistoryMutation();
            SearchHistoryUsers = new SearchHistoryUserMutation();
            StoryHighlights = new StoryHighlightMutation();
            Stories = new StoryMutation();
            UserPostTags = new UserPostTagMutation();
            Users = new UserMutation();
            UserSettings = new UserSettingMutation();
            ViewStories = new ViewStoryMutation();
            Logins = new LoginMutation();
            Registers = new RegisterMutation();
        }
    }
}
