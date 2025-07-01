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
using XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Self.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Self.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Admin.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Self.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Mutations;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Mutations;

namespace XenoTerra.WebAPI.GraphQL.Schemas._RootMutations
{
    public class UserMutation(
        BlockUserOwnMutation blockUsersOwn,
        CommentOwnMutation commentsOwn,
        CommentLikeOwnMutation commentLikesOwn,
        FollowOwnMutation followsOwn,
        HighlightOwnMutation highlightsOwn,
        MediaOwnMutation mediaOwn,
        MessageOwnMutation messagesOwn,
        NoteOwnMutation notesOwn,
        NotificationOwnMutation notificationsOwn,
        PostOwnMutation posts,
        PostLikeOwnMutation postLikesOwn,
        ReactionOwnMutation reactionsOwn,
        RecentChatsOwnMutation recentChatsOwn,
        ReportCommentOwnMutation reportCommentsOwn,
        ReportPostOwnMutation reportPostsOwn,
        ReportStoryOwnMutation reportStoriesOwn,
        SavedPostOwnMutation savedPostsOwn,
        SearchHistoryOwnMutation searchHistoriesOwn,
        StoryOwnMutation storiesOwn,
        StoryLikeOwnMutation storyLikesOwn,
        AppUserOwnMutation appUsersOwn,
        UserSettingOwnMutation userSettingsOwn,
        ViewStoryOwnMutation viewStoriesOwn)
    {
        public BlockUserOwnMutation BlockUsersOwn { get; } = blockUsersOwn;
        public CommentOwnMutation CommentsOwn { get; } = commentsOwn;
        public CommentLikeOwnMutation CommentLikesOwn { get; } = commentLikesOwn;
        public FollowOwnMutation FollowsOwn { get; } = followsOwn;
        public HighlightOwnMutation HighlightsOwn { get; } = highlightsOwn;
        public MediaOwnMutation MediaOwn { get; } = mediaOwn;
        public MessageOwnMutation MessagesOwn { get; } = messagesOwn;
        public NoteOwnMutation NotesOwn { get; } = notesOwn;
        public NotificationOwnMutation NotificationsOwn { get; } = notificationsOwn;
        public PostOwnMutation PostsOwn { get; } = posts;
        public PostLikeOwnMutation PostLikesOwn { get; } = postLikesOwn;
        public ReactionOwnMutation ReactionsOwn { get; } = reactionsOwn;
        public RecentChatsOwnMutation RecentChatsOwn { get; } = recentChatsOwn;
        public ReportCommentOwnMutation ReportCommentsOwn { get; } = reportCommentsOwn;
        public ReportPostOwnMutation ReportPostsOwn { get; } = reportPostsOwn;
        public ReportStoryOwnMutation ReportStoriesOwn { get; } = reportStoriesOwn;
        public SavedPostOwnMutation SavedPostsOwn { get; } = savedPostsOwn;
        public SearchHistoryOwnMutation SearchHistoriesOwn { get; } = searchHistoriesOwn;
        public StoryOwnMutation StoriesOwn { get; } = storiesOwn;
        public StoryLikeOwnMutation StoryLikesOwn { get; } = storyLikesOwn;
        public AppUserOwnMutation AppUsersOwn { get; } = appUsersOwn;
        public UserSettingOwnMutation UserSettingsOwn { get; } = userSettingsOwn;
        public ViewStoryOwnMutation ViewStoriesOwn { get; } = viewStoriesOwn;
    }

}
