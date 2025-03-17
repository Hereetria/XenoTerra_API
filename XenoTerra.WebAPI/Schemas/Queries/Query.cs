using XenoTerra.WebAPI.Schemas.Queries.BlockUserQueries;
using XenoTerra.WebAPI.Schemas.Queries.CommentQueries;
using XenoTerra.WebAPI.Schemas.Queries.FollowQueries;
using XenoTerra.WebAPI.Schemas.Queries.HighlightQueries;
using XenoTerra.WebAPI.Schemas.Queries.LikeQueries;
using XenoTerra.WebAPI.Schemas.Queries.MediaQueries;
using XenoTerra.WebAPI.Schemas.Queries.MessageQueries;
using XenoTerra.WebAPI.Schemas.Queries.NoteQueries;
using XenoTerra.WebAPI.Schemas.Queries.NotificationQueries;
using XenoTerra.WebAPI.Schemas.Queries.PostQueries;
//using XenoTerra.WebAPI.Schemas.Queries.PostTagQueries;
using XenoTerra.WebAPI.Schemas.Queries.ReactionQueries;
using XenoTerra.WebAPI.Schemas.Queries.RecentChatsQueries;
using XenoTerra.WebAPI.Schemas.Queries.ReportCommentQueries;
using XenoTerra.WebAPI.Schemas.Queries.RoleQueries;
using XenoTerra.WebAPI.Schemas.Queries.SavedPostQueries;
using XenoTerra.WebAPI.Schemas.Queries.SearchHistoryQueries;
using XenoTerra.WebAPI.Schemas.Queries.StoryQueries;
using XenoTerra.WebAPI.Schemas.Queries.UserQueries;
using XenoTerra.WebAPI.Schemas.Queries.UserSettingQueries;
using XenoTerra.WebAPI.Schemas.Queries.ViewStoryQueries;

namespace XenoTerra.WebAPI.Schemas.Queries
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

