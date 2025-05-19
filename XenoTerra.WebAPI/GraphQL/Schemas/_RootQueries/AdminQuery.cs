using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Admin.Queries;

namespace XenoTerra.WebAPI.GraphQL.Schemas._RootQueries
{
    public class AdminQuery(
        BlockUserAdminQuery blockUsers,
        CommentAdminQuery comments,
        FollowAdminQuery follows,
        HighlightAdminQuery highlights,
        LikeAdminQuery likes,
        MediaAdminQuery media,
        MessageAdminQuery messages,
        NoteAdminQuery notes,
        NotificationAdminQuery notifications,
        PostAdminQuery posts,
        ReactionAdminQuery reactions,
        RecentChatsAdminQuery recentChats,
        ReportCommentAdminQuery reportComments,
        RoleAdminQuery roles,
        SavedPostAdminQuery savedPosts,
        SearchHistoryAdminQuery searchHistories,
        StoryAdminQuery stories,
        UserAdminQuery users,
        UserSettingAdminQuery userSettings,
        ViewStoryAdminQuery viewStories)
    {
        public BlockUserAdminQuery BlockUsers { get; } = blockUsers;
        public CommentAdminQuery Comments { get; } = comments;
        public FollowAdminQuery Follows { get; } = follows;
        public HighlightAdminQuery Highlights { get; } = highlights;
        public LikeAdminQuery Likes { get; } = likes;
        public MediaAdminQuery Media { get; } = media;
        public MessageAdminQuery Messages { get; } = messages;
        public NoteAdminQuery Notes { get; } = notes;
        public NotificationAdminQuery Notifications { get; } = notifications;
        public PostAdminQuery Posts { get; } = posts;
        public ReactionAdminQuery Reactions { get; } = reactions;
        public RecentChatsAdminQuery RecentChats { get; } = recentChats;
        public ReportCommentAdminQuery ReportComments { get; } = reportComments;
        public RoleAdminQuery Roles { get; } = roles;
        public SavedPostAdminQuery SavedPosts { get; } = savedPosts;
        public SearchHistoryAdminQuery SearchHistories { get; } = searchHistories;
        public StoryAdminQuery Stories { get; } = stories;
        public UserAdminQuery Users { get; } = users;
        public UserSettingAdminQuery UserSettings { get; } = userSettings;
        public ViewStoryAdminQuery ViewStories { get; } = viewStories;
    }

}
