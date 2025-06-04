using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Self.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Mutations;

namespace XenoTerra.WebAPI.GraphQL.Schemas._RootMutations
{
    public class UserMutation(
        BlockUserSelfMutation blockUsers,
        CommentSelfMutation comments,
        CommentLikeSelfMutation commentLikes,
        FollowSelfMutation follows,
        HighlightSelfMutation highlights,
        MediaSelfMutation media,
        MessageSelfMutation messages,
        NoteSelfMutation notes,
        NotificationSelfMutation notifications,
        PostSelfMutation posts,
        PostLikeSelfMutation postLikes,
        ReactionSelfMutation reactions,
        RecentChatsSelfMutation recentChats,
        ReportCommentSelfMutation reportComments,
        ReportPostSelfMutation reportPosts,
        SavedPostSelfMutation savedPosts,
        SearchHistorySelfMutation searchHistories,
        StorySelfMutation stories,
        AppUserSelfMutation users,
        UserSettingSelfMutation userSettings,
        ViewStorySelfMutation viewStories)
    {
        public BlockUserSelfMutation BlockUsers { get; } = blockUsers;
        public CommentSelfMutation Comments { get; } = comments;
        public CommentLikeSelfMutation CommentLikes { get; } = commentLikes;
        public FollowSelfMutation Follows { get; } = follows;
        public HighlightSelfMutation Highlights { get; } = highlights;
        public MediaSelfMutation Media { get; } = media;
        public MessageSelfMutation Messages { get; } = messages;
        public NoteSelfMutation Notes { get; } = notes;
        public NotificationSelfMutation Notifications { get; } = notifications;
        public PostSelfMutation Posts { get; } = posts;
        public PostLikeSelfMutation PostLikes { get; } = postLikes;
        public ReactionSelfMutation Reactions { get; } = reactions;
        public RecentChatsSelfMutation RecentChats { get; } = recentChats;
        public ReportCommentSelfMutation ReportComments { get; } = reportComments;
        public ReportPostSelfMutation ReportPosts { get; } = reportPosts;
        public SavedPostSelfMutation SavedPosts { get; } = savedPosts;
        public SearchHistorySelfMutation SearchHistories { get; } = searchHistories;
        public StorySelfMutation Stories { get; } = stories;
        public AppUserSelfMutation Users { get; } = users;
        public UserSettingSelfMutation UserSettings { get; } = userSettings;
        public ViewStorySelfMutation ViewStories { get; } = viewStories;
    }

}
