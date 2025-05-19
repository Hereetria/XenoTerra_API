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
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Admin.Mutations;

namespace XenoTerra.WebAPI.GraphQL.Schemas._RootMutations
{
    public class AdminMutation(
        BlockUserAdminMutation blockUsers,
        CommentAdminMutation comments,
        FollowAdminMutation follows,
        HighlightAdminMutation highlights,
        LikeAdminMutation likes,
        MediaAdminMutation media,
        MessageAdminMutation messages,
        NoteAdminMutation notes,
        NotificationAdminMutation notifications,
        PostAdminMutation posts,
        ReactionAdminMutation reactions,
        RecentChatsAdminMutation recentChats,
        ReportCommentAdminMutation reportComments,
        RoleAdminMutation roles,
        SavedPostAdminMutation savedPosts,
        SearchHistoryAdminMutation searchHistories,
        StoryAdminMutation stories,
        UserAdminMutation users,
        UserSettingAdminMutation userSettings,
        ViewStoryAdminMutation viewStories)
    {
        public BlockUserAdminMutation BlockUsers { get; } = blockUsers;
        public CommentAdminMutation Comments { get; } = comments;
        public FollowAdminMutation Follows { get; } = follows;
        public HighlightAdminMutation Highlights { get; } = highlights;
        public LikeAdminMutation Likes { get; } = likes;
        public MediaAdminMutation Media { get; } = media;
        public MessageAdminMutation Messages { get; } = messages;
        public NoteAdminMutation Notes { get; } = notes;
        public NotificationAdminMutation Notifications { get; } = notifications;
        public PostAdminMutation Posts { get; } = posts;
        public ReactionAdminMutation Reactions { get; } = reactions;
        public RecentChatsAdminMutation RecentChats { get; } = recentChats;
        public ReportCommentAdminMutation ReportComments { get; } = reportComments;
        public RoleAdminMutation Roles { get; } = roles;
        public SavedPostAdminMutation SavedPosts { get; } = savedPosts;
        public SearchHistoryAdminMutation SearchHistories { get; } = searchHistories;
        public StoryAdminMutation Stories { get; } = stories;
        public UserAdminMutation Users { get; } = users;
        public UserSettingAdminMutation UserSettings { get; } = userSettings;
        public ViewStoryAdminMutation ViewStories { get; } = viewStories;
    }
}
