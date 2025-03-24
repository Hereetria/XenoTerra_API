using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.BlockUserQueries;
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
using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.RoleQueries;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.SavedPostQueries;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.SearchHistoryQueries;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.StoryQueries;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.UserQueries;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.UserSettingQueries;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.ViewStoryQueries;











//using XenoTerra.WebAPI.Schemas.Queries.PostTagQueries;

namespace XenoTerra.WebAPI.GraphQL.Schemas
{
        public class Query
        {
            public BlockUserQuery BlockUsers { get; }
            public CommentQuery Comments { get; }
            public FollowQuery Follows { get; }
            public HighlightQuery Highlights { get; }
            public LikeQuery Likes { get; }
            public MediaQuery Media { get; }
            public MessageQuery Messages { get; }
            public NoteQuery Notes { get; }
            public NotificationQuery Notifications { get; }
            public PostQuery Posts { get; }
            public ReactionQuery Reactions { get; }
            public RecentChatsQuery RecentChats { get; }
            public ReportCommentQuery ReportComments { get; }
            public RoleQuery Roles { get; }
            public SavedPostQuery SavedPosts { get; }
            public SearchHistoryQuery SearchHistories { get; }
            public StoryQuery Stories { get; }
            public UserQuery Users { get; }
            public UserSettingQuery UserSettings { get; }
            public ViewStoryQuery ViewStories { get; }

            public Query(
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
                BlockUsers = blockUsers;
                Comments = comments;
                Follows = follows;
                Highlights = highlights;
                Likes = likes;
                Media = media;
                Messages = messages;
                Notes = notes;
                Notifications = notifications;
                Posts = posts;
                Reactions = reactions;
                RecentChats = recentChats;
                ReportComments = reportComments;
                Roles = roles;
                SavedPosts = savedPosts;
                SearchHistories = searchHistories;
                Stories = stories;
                Users = users;
                UserSettings = userSettings;
                ViewStories = viewStories;
            }
        }
    }

