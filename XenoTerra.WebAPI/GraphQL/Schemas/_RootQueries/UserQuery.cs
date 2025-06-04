using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.AppRoleSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Queries;

namespace XenoTerra.WebAPI.GraphQL.Schemas._RootQueries
{
    public class UserQuery(
        BlockUserSelfQuery blockUsers,
        CommentSelfQuery comments,
        CommentLikeSelfQuery commentLikes,
        FollowSelfQuery follows,
        HighlightSelfQuery highlights,
        MediaSelfQuery media,
        MessageSelfQuery messages,
        NoteSelfQuery notes,
        NotificationSelfQuery notifications,
        PostSelfQuery posts,
        PostLikeSelfQuery postLikes,
        ReactionSelfQuery reactions,
        RecentChatsSelfQuery recentChats,
        ReportCommentSelfQuery reportComments,
        ReportPostSelfQuery reportPosts,
        SavedPostSelfQuery savedPosts,
        SearchHistorySelfQuery searchHistories,
        StorySelfQuery stories,
        AppUserPrivateSelfQuery usersPrivate,
        AppUserPublicSelfQuery usersPublic,
        UserSettingSelfQuery userSettings,
        ViewStorySelfQuery viewStories)
    {
        public BlockUserSelfQuery BlockUsers { get; } = blockUsers;
        public CommentSelfQuery Comments { get; } = comments;
        public CommentLikeSelfQuery CommentLikes { get; } = commentLikes;
        public FollowSelfQuery Follows { get; } = follows;
        public HighlightSelfQuery Highlights { get; } = highlights;
        public MediaSelfQuery Media { get; } = media;
        public MessageSelfQuery Messages { get; } = messages;
        public NoteSelfQuery Notes { get; } = notes;
        public NotificationSelfQuery Notifications { get; } = notifications;
        public PostSelfQuery Posts { get; } = posts;
        public PostLikeSelfQuery PostLikes { get; } = postLikes;
        public ReactionSelfQuery Reactions { get; } = reactions;
        public RecentChatsSelfQuery RecentChats { get; } = recentChats;
        public ReportCommentSelfQuery ReportComments { get; } = reportComments;
        public ReportPostSelfQuery ReportPosts { get; } = reportPosts;
        public SavedPostSelfQuery SavedPosts { get; } = savedPosts;
        public SearchHistorySelfQuery SearchHistories { get; } = searchHistories;
        public StorySelfQuery Stories { get; } = stories;
        public AppUserPrivateSelfQuery UsersPrivate { get; } = usersPrivate;
        public AppUserPublicSelfQuery UsersPublic { get; } = usersPublic;
        public UserSettingSelfQuery UserSettings { get; } = userSettings;
        public ViewStorySelfQuery ViewStories { get; } = viewStories;
    }
}
