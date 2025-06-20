using XenoTerra.WebAPI.GraphQL.Schemas.AppRoleSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Admin.Mutations;

namespace XenoTerra.WebAPI.GraphQL.Schemas._RootMutations
{
    public class AdminMutation(
        BlockUserAdminMutation blockUsers,
        CommentAdminMutation comments,
        CommentLikeAdminMutation commentLikes,
        FollowAdminMutation follows,
        HighlightAdminMutation highlights,
        MediaAdminMutation media,
        MessageAdminMutation messages,
        NoteAdminMutation notes,
        NotificationAdminMutation notifications,
        PostAdminMutation posts,
        PostLikeAdminMutation postLikes,
        ReactionAdminMutation reactions,
        RecentChatsAdminMutation recentChats,
        ReportCommentAdminMutation reportComments,
        ReportPostAdminMutation reportPosts,
        ReportStoryAdminMutation reportStories,
        AppRoleAdminMutation appRoles,
        SavedPostAdminMutation savedPosts,
        SearchHistoryAdminMutation searchHistories,
        StoryAdminMutation stories,
        StoryLikeAdminMutation storyLikes,
        AppUserAdminMutation appUsers,
        UserSettingAdminMutation userSettings,
        ViewStoryAdminMutation viewStories)
    {
        public BlockUserAdminMutation BlockUsers { get; } = blockUsers;
        public CommentAdminMutation Comments { get; } = comments;
        public CommentLikeAdminMutation CommentLikes { get; } = commentLikes;
        public FollowAdminMutation Follows { get; } = follows;
        public HighlightAdminMutation Highlights { get; } = highlights;
        public MediaAdminMutation Media { get; } = media;
        public MessageAdminMutation Messages { get; } = messages;
        public NoteAdminMutation Notes { get; } = notes;
        public NotificationAdminMutation Notifications { get; } = notifications;
        public PostAdminMutation Posts { get; } = posts;
        public PostLikeAdminMutation PostLikes { get; } = postLikes;
        public ReactionAdminMutation Reactions { get; } = reactions;
        public RecentChatsAdminMutation RecentChats { get; } = recentChats;
        public ReportCommentAdminMutation ReportComments { get; } = reportComments;
        public ReportPostAdminMutation ReportPosts { get; } = reportPosts;
        public ReportStoryAdminMutation ReportStories { get; } = reportStories;
        public AppRoleAdminMutation AppRoles { get; } = appRoles;
        public SavedPostAdminMutation SavedPosts { get; } = savedPosts;
        public SearchHistoryAdminMutation SearchHistories { get; } = searchHistories;
        public StoryAdminMutation Stories { get; } = stories;
        public StoryLikeAdminMutation StoryLikes { get; } = storyLikes;
        public AppUserAdminMutation AppUsers { get; } = appUsers;
        public UserSettingAdminMutation UserSettings { get; } = userSettings;
        public ViewStoryAdminMutation ViewStories { get; } = viewStories;
    }
}
