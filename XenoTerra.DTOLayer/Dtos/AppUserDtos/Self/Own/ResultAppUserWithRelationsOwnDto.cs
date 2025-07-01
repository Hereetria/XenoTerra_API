using XenoTerra.DTOLayer.Dtos.BlockUserDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.CommentDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.FollowDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.HighlightDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.MediaDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.MessageDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.NoteDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.NotificationDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.PostDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.PostLikeDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.RecentChatsDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.ReportPostDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.ReportStoryDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.SavedPostDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.StoryDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.StoryLikeDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.UserPostTagDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.UserSettingDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos.Self.Own;

namespace XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Own
{
    public class ResultAppUserWithRelationsOwnDto
    {
        public Guid Id { get; init; }
        public string UserName { get; init; } = string.Empty;
        public string Password { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public string FullName { get; init; } = string.Empty;
        public string Bio { get; init; } = string.Empty;
        public string ProfilePicture { get; init; } = string.Empty;
        public string Website { get; init; } = string.Empty;
        public DateTime BirthDate { get; init; }
        public int FollowersCount { get; init; }
        public int FollowingCount { get; init; }
        public bool IsVerified { get; init; }
        public DateTime LastActive { get; init; }


        public ICollection<ResultBlockUserOwnDto> BlockingUsers { get; set; } = [];
        public ICollection<ResultPostOwnDto> Posts { get; set; } = [];

        public ICollection<ResultFollowOwnDto> Followers { get; set; } = [];

        public ICollection<ResultFollowOwnDto> Followings { get; set; } = [];

        public ICollection<ResultPostLikeOwnDto> PostLikes { get; set; } = [];
        public ICollection<ResultStoryLikeOwnDto> StoryLikes { get; set; } = [];

        public ICollection<ResultCommentOwnDto> Comments { get; set; } = [];

        public ICollection<ResultHighlightOwnDto> Highlights { get; set; } = [];

        public ICollection<ResultMessageOwnDto> SentMessages { get; set; } = [];

        public ICollection<ResultMessageOwnDto> ReceivedMessages { get; set; } = [];

        public ICollection<ResultNotificationOwnDto> Notifications { get; set; } = [];

        public ICollection<ResultMediaOwnDto> SentMedias { get; set; } = [];

        public ICollection<ResultMediaOwnDto> ReceivedMedias { get; set; } = [];

        public ICollection<ResultStoryOwnDto> Stories { get; set; } = [];

        public ICollection<ResultSavedPostOwnDto> SavedPosts { get; set; } = [];

        public ICollection<ResultReportCommentOwnDto> ReportComments { get; set; } = [];
        public ICollection<ResultReportPostOwnDto> ReportPosts { get; set; } = [];
        public ICollection<ResultReportStoryOwnDto> ReportStories { get; set; } = [];

        public ICollection<ResultViewStoryOwnDto> ViewStories { get; set; } = [];

        public ResultUserSettingOwnDto UserSetting { get; set; } = null!;

        public ICollection<ResultSearchHistoryOwnDto> PerformedSearches { get; set; } = [];

        public ICollection<ResultRecentChatsOwnDto> RecentChats { get; set; } = [];

        public ResultNoteOwnDto Note { get; set; } = null!;
        public ICollection<ResultUserPostTagOwnDto> TaggedPosts { get; set; } = [];
    }
}