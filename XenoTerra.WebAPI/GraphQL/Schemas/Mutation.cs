using AutoMapper;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.MessageMutations;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.NoteMutations;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.PostMutations;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.ReportCommentMutations;
using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.SavedPostMutations;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.SearchHistoryMutations;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Mutations;
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
        }
    }
}
