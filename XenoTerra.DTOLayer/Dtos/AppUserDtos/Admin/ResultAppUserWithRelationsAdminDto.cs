using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.CommentDtos.Admin;
using XenoTerra.DTOLayer.Dtos.FollowDtos.Admin;
using XenoTerra.DTOLayer.Dtos.HighlightDtos.Admin;
using XenoTerra.DTOLayer.Dtos.MediaDtos.Admin;
using XenoTerra.DTOLayer.Dtos.MessageDtos.Admin;
using XenoTerra.DTOLayer.Dtos.NoteDtos.Admin;
using XenoTerra.DTOLayer.Dtos.NotificationDtos.Admin;
using XenoTerra.DTOLayer.Dtos.PostDtos.Admin;
using XenoTerra.DTOLayer.Dtos.PostLikeDtos.Admin;
using XenoTerra.DTOLayer.Dtos.RecentChatsDtos.Admin;
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos.Admin;
using XenoTerra.DTOLayer.Dtos.ReportPostDtos.Admin;
using XenoTerra.DTOLayer.Dtos.ReportStoryDtos.Admin;
using XenoTerra.DTOLayer.Dtos.SavedPostDtos.Admin;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos.Admin;
using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.StoryDtos.Admin;
using XenoTerra.DTOLayer.Dtos.StoryLikeDtos.Admin;
using XenoTerra.DTOLayer.Dtos.UserPostTagDtos.Admin;
using XenoTerra.DTOLayer.Dtos.UserSettingDtos.Admin;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos.Admin;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin
{
    public class ResultAppUserWithRelationsAdminDto
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

        public ICollection<ResultBlockUserAdminDto> BlockedUsers { get; set; } = [];

        public ICollection<ResultBlockUserAdminDto> BlockingUsers { get; set; } = [];
        public ICollection<ResultPostAdminDto> Posts { get; set; } = [];

        public ICollection<ResultFollowAdminDto> Followers { get; set; } = [];

        public ICollection<ResultFollowAdminDto> Followings { get; set; } = [];

        public ICollection<ResultPostLikeAdminDto> PostLikes { get; set; } = [];
        public ICollection<ResultStoryLikeAdminDto> StoryLikes { get; set; } = [];

        public ICollection<ResultCommentAdminDto> Comments { get; set; } = [];

        public ICollection<ResultHighlightAdminDto> Highlights { get; set; } = [];

        public ICollection<ResultMessageAdminDto> SentMessages { get; set; } = [];

        public ICollection<ResultMessageAdminDto> ReceivedMessages { get; set; } = [];

        public ICollection<ResultNotificationAdminDto> Notifications { get; set; } = [];

        public ICollection<ResultMediaAdminDto> SentMedias { get; set; } = [];

        public ICollection<ResultMediaAdminDto> ReceivedMedias { get; set; } = [];

        public ICollection<ResultStoryAdminDto> Stories { get; set; } = [];

        public ICollection<ResultSavedPostAdminDto> SavedPosts { get; set; } = [];

        public ICollection<ResultReportCommentAdminDto> ReportComments { get; set; } = [];
        public ICollection<ResultReportPostAdminDto> ReportPosts { get; set; } = [];
        public ICollection<ResultReportStoryAdminDto> ReportStories { get; set; } = [];

        public ICollection<ResultViewStoryAdminDto> ViewStories { get; set; } = [];

        public ResultUserSettingAdminDto UserSetting { get; set; } = null!;

        public ICollection<ResultSearchHistoryAdminDto> PerformedSearches { get; set; } = [];
        public ICollection<ResultSearchHistoryUserAdminDto> WasSearchedBy { get; set; } = [];

        public ICollection<ResultRecentChatsAdminDto> RecentChats { get; set; } = [];

        public ResultNoteAdminDto Note { get; set; } = null!;
        public ICollection<ResultUserPostTagAdminDto> TaggedPosts { get; set; } = [];
    }
}
