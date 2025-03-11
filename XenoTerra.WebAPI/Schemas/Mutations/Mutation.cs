using XenoTerra.WebAPI.Schemas.Mutations.BlockUserMutations;
using XenoTerra.WebAPI.Schemas.Mutations.CommentMutations;
using XenoTerra.WebAPI.Schemas.Mutations.FollowMutations;
using XenoTerra.WebAPI.Schemas.Mutations.HighlightMutations;
using XenoTerra.WebAPI.Schemas.Mutations.LikeMutations;
using XenoTerra.WebAPI.Schemas.Mutations.MediaMutations;
using XenoTerra.WebAPI.Schemas.Mutations.MessageMutations;
using XenoTerra.WebAPI.Schemas.Mutations.NoteMutations;
using XenoTerra.WebAPI.Schemas.Mutations.NotificationMutations;
using XenoTerra.WebAPI.Schemas.Mutations.PostMutations;
using XenoTerra.WebAPI.Schemas.Mutations.PostTagMutations;
using XenoTerra.WebAPI.Schemas.Mutations.ReactionMutations;
using XenoTerra.WebAPI.Schemas.Mutations.RecentChatsMutations;
using XenoTerra.WebAPI.Schemas.Mutations.ReportCommentMutations;
using XenoTerra.WebAPI.Schemas.Mutations.RoleMutations;
using XenoTerra.WebAPI.Schemas.Mutations.SavedPostMutations;
using XenoTerra.WebAPI.Schemas.Mutations.SearchHistoryMutations;
using XenoTerra.WebAPI.Schemas.Mutations.SearchHistoryUserMutations;
using XenoTerra.WebAPI.Schemas.Mutations.StoryMutations;
using XenoTerra.WebAPI.Schemas.Mutations.UserMutations;
using XenoTerra.WebAPI.Schemas.Mutations.UserSettingMutations;
using XenoTerra.WebAPI.Schemas.Mutations.ViewStoryMutations;

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
