using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Queries;

namespace XenoTerra.WebAPI.GraphQL.Schemas._RootQueries
{
    public class UserQuery(
        BlockUserSelfQuery blockUsers,
        CommentSelfQuery comments,
        FollowSelfQuery follows,
        HighlightSelfQuery highlights,
        LikeSelfQuery likes,
        MediaSelfQuery media,
        MessageSelfQuery messages,
        NoteSelfQuery notes,
        NotificationSelfQuery notifications,
        PostSelfQuery posts,
        ReactionSelfQuery reactions,
        RecentChatsSelfQuery recentChats,
        ReportCommentSelfQuery reportComments,
        SavedPostSelfQuery savedPosts,
        SearchHistorySelfQuery searchHistories,
        StorySelfQuery stories,
        UserPublicSelfQuery usersPublic,
        UserPrivateSelfQuery usersPrivate,
        UserSettingSelfQuery userSettings,
        ViewStorySelfQuery viewStories)
    {
        public BlockUserSelfQuery BlockUsers { get; } = blockUsers;
        public CommentSelfQuery Comments { get; } = comments;
        public FollowSelfQuery Follows { get; } = follows;
        public HighlightSelfQuery Highlights { get; } = highlights;
        public LikeSelfQuery Likes { get; } = likes;
        public MediaSelfQuery Media { get; } = media;
        public MessageSelfQuery Messages { get; } = messages;
        public NoteSelfQuery Notes { get; } = notes;
        public NotificationSelfQuery Notifications { get; } = notifications;
        public PostSelfQuery Posts { get; } = posts;
        public ReactionSelfQuery Reactions { get; } = reactions;
        public RecentChatsSelfQuery RecentChats { get; } = recentChats;
        public ReportCommentSelfQuery ReportComments { get; } = reportComments;
        public SavedPostSelfQuery SavedPosts { get; } = savedPosts;
        public SearchHistorySelfQuery SearchHistories { get; } = searchHistories;
        public StorySelfQuery Stories { get; } = stories;
        public UserPublicSelfQuery UsersPublic { get; } = usersPublic;
        public UserPrivateSelfQuery UsersPrivate { get; } = usersPrivate;
        public UserSettingSelfQuery UserSettings { get; } = userSettings;
        public ViewStorySelfQuery ViewStories { get; } = viewStories;
    }
}
