using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using XenoTerra.WebAPI.GraphQL.Schemas.AppRoleSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Own.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Admin.Queries;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Queries;

namespace XenoTerra.WebAPI.GraphQL.Schemas._RootQueries
{
    public class UserQuery(
        AppUserOwnQuery appUsersOwn,
        AppUserPublicQuery appUsersPublic,
        CommentOwnQuery commentsOwn,
        CommentPublicQuery commentsPublic,
        CommentLikeOwnQuery commentLikesOwn,
        CommentLikePublicQuery commentLikesPublic,
        FollowOwnQuery followsOwn,
        FollowPublicQuery followsPublic,
        HighlightOwnQuery highlightsOwn,
        HighlightPublicQuery highlightsPublic,
        NotificationOwnQuery notificationsOwn,
        NoteOwnQuery notesOwn,
        NotePublicQuery notesPublic,
        PostOwnQuery postsOwn,
        PostPublicQuery postsPublic,
        PostLikeOwnQuery postLikesOwn,
        PostLikePublicQuery postLikesPublic,
        StoryOwnQuery storiesOwn,
        StoryPublicQuery storiesPublic,
        UserPostTagOwnQuery userPostTagsOwn,
        UserPostTagPublicQuery userPostTagsPublic,
        BlockUserOwnQuery blockUsersOwn,
        MediaOwnQuery mediaOwn,
        MessageOwnQuery messagesOwn,
        ReactionOwnQuery reactionsOwn,
        RecentChatsOwnQuery recentChatsOwn,
        ReportCommentOwnQuery reportCommentsOwn,
        ReportPostOwnQuery reportPostsOwn,
        StoryLikeOwnQuery storyLikesOwn,
        ReportStoryOwnQuery reportStoriesOwn,
        SavedPostOwnQuery savedPostsOwn,
        SearchHistoryOwnQuery searchHistoriesOwn,
        UserSettingOwnQuery userSettingsOwn,
        ViewStoryOwnQuery viewStoriesOwn
    )
    {
        public AppUserOwnQuery UsersOwn { get; } = appUsersOwn;
        public AppUserPublicQuery UsersPublic { get; } = appUsersPublic;

        public CommentOwnQuery CommentsOwn { get; } = commentsOwn;
        public CommentPublicQuery CommentsPublic { get; } = commentsPublic;

        public CommentLikeOwnQuery CommentLikesOwn { get; } = commentLikesOwn;
        public CommentLikePublicQuery CommentLikesPublic { get; } = commentLikesPublic;

        public FollowOwnQuery FollowsOwn { get; } = followsOwn;
        public FollowPublicQuery FollowsPublic { get; } = followsPublic;

        public HighlightOwnQuery HighlightsOwn { get; } = highlightsOwn;
        public HighlightPublicQuery HighlightsPublic { get; } = highlightsPublic;

        public NotificationOwnQuery NotificationsOwn { get; } = notificationsOwn;

        public NoteOwnQuery NotesOwn { get; } = notesOwn;
        public NotePublicQuery NotesPublic { get; } = notesPublic;

        public PostOwnQuery PostsOwn { get; } = postsOwn;
        public PostPublicQuery PostsPublic { get; } = postsPublic;

        public PostLikeOwnQuery PostLikesOwn { get; } = postLikesOwn;
        public PostLikePublicQuery PostLikesPublic { get; } = postLikesPublic;

        public StoryOwnQuery StoriesOwn { get; } = storiesOwn;
        public StoryPublicQuery StoriesPublic { get; } = storiesPublic;

        public UserPostTagOwnQuery UserPostTagsOwn { get; } = userPostTagsOwn;
        public UserPostTagPublicQuery UserPostTagsPublic { get; } = userPostTagsPublic;

        public BlockUserOwnQuery BlockUsersOwn { get; } = blockUsersOwn;
        public MediaOwnQuery MediaOwn { get; } = mediaOwn;
        public MessageOwnQuery MessagesOwn { get; } = messagesOwn;
        public ReactionOwnQuery ReactionsOwn { get; } = reactionsOwn;
        public RecentChatsOwnQuery RecentChatsOwn { get; } = recentChatsOwn;
        public ReportCommentOwnQuery ReportCommentsOwn { get; } = reportCommentsOwn;
        public ReportPostOwnQuery ReportPostsOwn { get; } = reportPostsOwn;
        public StoryLikeOwnQuery StoryLikesOwn { get; } = storyLikesOwn;
        public ReportStoryOwnQuery ReportStoriesOwn { get; } = reportStoriesOwn;
        public SavedPostOwnQuery SavedPostsOwn { get; } = savedPostsOwn;
        public SearchHistoryOwnQuery SearchHistoriesOwn { get; } = searchHistoriesOwn;
        public UserSettingOwnQuery UserSettingsOwn { get; } = userSettingsOwn;
        public ViewStoryOwnQuery ViewStoriesOwn { get; } = viewStoriesOwn;

    }

}
