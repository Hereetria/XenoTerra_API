using XenoTerra.WebAPI.GraphQL.Schemas.AppRoleSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Admin.Queries;

namespace XenoTerra.WebAPI.GraphQL.Schemas._RootQueries
{
    public class AdminQuery(
        BlockUserAdminQuery blockUsers,
        CommentAdminQuery comments,
        CommentLikeAdminQuery commentLikes,
        FollowAdminQuery follows,
        HighlightAdminQuery highlights,
        MediaAdminQuery media,
        MessageAdminQuery messages,
        NoteAdminQuery notes,
        NotificationAdminQuery notifications,
        PostAdminQuery posts,
        PostLikeAdminQuery postLikes,
        ReactionAdminQuery reactions,
        RecentChatsAdminQuery recentChats,
        ReportCommentAdminQuery reportComments,
        ReportPostAdminQuery reportPosts,
        StoryLikeAdminQuery storyLikes,
        ReportStoryAdminQuery reportStories,
        AppRoleAdminQuery appRoles,
        SavedPostAdminQuery savedPosts,
        SearchHistoryAdminQuery searchHistories,
        StoryAdminQuery stories,
        AppUserAdminQuery appUsers,
        UserSettingAdminQuery userSettings,
        ViewStoryAdminQuery viewStories)
    {
        public BlockUserAdminQuery BlockUsers { get; } = blockUsers;
        public CommentAdminQuery Comments { get; } = comments;
        public CommentLikeAdminQuery CommentLikes { get; } = commentLikes;
        public FollowAdminQuery Follows { get; } = follows;
        public HighlightAdminQuery Highlights { get; } = highlights;
        public MediaAdminQuery Media { get; } = media;
        public MessageAdminQuery Messages { get; } = messages;
        public NoteAdminQuery Notes { get; } = notes;
        public NotificationAdminQuery Notifications { get; } = notifications;
        public PostAdminQuery Posts { get; } = posts;
        public PostLikeAdminQuery PostLikes { get; } = postLikes;
        public ReactionAdminQuery Reactions { get; } = reactions;
        public RecentChatsAdminQuery RecentChats { get; } = recentChats;
        public ReportCommentAdminQuery ReportComments { get; } = reportComments;
        public ReportPostAdminQuery ReportPosts { get; } = reportPosts;
        public StoryLikeAdminQuery StoryLikes { get; } = storyLikes;
        public ReportStoryAdminQuery ReportStories { get; } = reportStories;
        public AppRoleAdminQuery Roles { get; } = appRoles;
        public SavedPostAdminQuery SavedPosts { get; } = savedPosts;
        public SearchHistoryAdminQuery SearchHistories { get; } = searchHistories;
        public StoryAdminQuery Stories { get; } = stories;
        public AppUserAdminQuery Users { get; } = appUsers;
        public UserSettingAdminQuery UserSettings { get; } = userSettings;
        public ViewStoryAdminQuery ViewStories { get; } = viewStories;
    }


}
