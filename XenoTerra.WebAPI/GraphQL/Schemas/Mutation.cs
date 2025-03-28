using AutoMapper;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.CommentMutations;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.FollowMutations;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.HighlightMutations;
using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.LikeMutations;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.MediaMutations;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.MessageMutations;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.NoteMutations;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.NotificationMutations;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.PostMutations;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.ReactionMutations;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.RecentChatsMutations;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.ReportCommentMutations;
using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.RoleMutations;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.SavedPostMutations;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.SearchHistoryMutations;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.StoryMutations;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.UserMutations;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.UserSettingMutations;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.ViewStoryMutations;

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
        public StoryMutation Stories { get; }
        public UserMutation Users { get; }
        public UserSettingMutation UserSettings { get; }
        public ViewStoryMutation ViewStories { get; }

        public Mutation(IMapper mapper)
        {
            BlockUsers = new BlockUserMutation(mapper);
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
            Stories = new StoryMutation();
            Users = new UserMutation();
            UserSettings = new UserSettingMutation();
            ViewStories = new ViewStoryMutation();
        }
    }
}
