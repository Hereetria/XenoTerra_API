using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.CommentQueries;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.FollowQueries;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.HighlightQueries;
using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.LikeQueries;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.MediaQueries;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.MessageQueries;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.NoteQueries;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.NotificationQueries;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.PostQueries;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.ReactionQueries;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.RecentChatsQueries;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.ReportCommentQueries;
using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.SavedPostQueries;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.SearchHistoryQueries;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.StoryQueries;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.UserQueries;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.UserSettingQueries;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.ViewStoryQueries;

namespace XenoTerra.WebAPI.GraphQL.Schemas
{
    public class Query(
        BlockUserQuery blockUsers,
        CommentQuery comments,
        FollowQuery follows,
        HighlightQuery highlights,
        LikeQuery likes,
        MediaQuery media,
        MessageQuery messages,
        NoteQuery notes,
        NotificationQuery notifications,
        PostQuery posts,
        ReactionQuery reactions,
        RecentChatsQuery recentChats,
        ReportCommentQuery reportComments,
        RoleQuery roles,
        SavedPostQuery savedPosts,
        SearchHistoryQuery searchHistories,
        StoryQuery stories,
        UserQuery users,
        UserSettingQuery userSettings,
        ViewStoryQuery viewStories)
    {
        public BlockUserQuery BlockUsers { get; } = blockUsers;
        public CommentQuery Comments { get; } = comments;
        public FollowQuery Follows { get; } = follows;
        public HighlightQuery Highlights { get; } = highlights;
        public LikeQuery Likes { get; } = likes;
        public MediaQuery Media { get; } = media;
        public MessageQuery Messages { get; } = messages;
        public NoteQuery Notes { get; } = notes;
        public NotificationQuery Notifications { get; } = notifications;
        public PostQuery Posts { get; } = posts;
        public ReactionQuery Reactions { get; } = reactions;
        public RecentChatsQuery RecentChats { get; } = recentChats;
        public ReportCommentQuery ReportComments { get; } = reportComments;
        public RoleQuery Roles { get; } = roles;
        public SavedPostQuery SavedPosts { get; } = savedPosts;
        public SearchHistoryQuery SearchHistories { get; } = searchHistories;
        public StoryQuery Stories { get; } = stories;
        public UserQuery Users { get; } = users;
        public UserSettingQuery UserSettings { get; } = userSettings;
        public ViewStoryQuery ViewStories { get; } = viewStories;
    }
}