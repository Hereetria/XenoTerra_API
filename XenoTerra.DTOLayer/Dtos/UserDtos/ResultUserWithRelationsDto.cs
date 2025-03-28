

using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.DTOLayer.Dtos.CommentDtos;
using XenoTerra.DTOLayer.Dtos.FollowDtos;
using XenoTerra.DTOLayer.Dtos.LikeDtos;
using XenoTerra.DTOLayer.Dtos.MediaDtos;
using XenoTerra.DTOLayer.Dtos.MessageDtos;
using XenoTerra.DTOLayer.Dtos.NoteDtos;
using XenoTerra.DTOLayer.Dtos.NotificationDtos;
using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.DTOLayer.Dtos.ReactionDtos;
using XenoTerra.DTOLayer.Dtos.RecentChatsDtos;
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;
using XenoTerra.DTOLayer.Dtos.SavedPostDtos;
using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.DTOLayer.Dtos.UserSettingDtos;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DTOLayer.Dtos.UserDtos
{
    public record ResultUserWithRelationsDto(
        Guid Id,
        string UserName,
        string Password,
        string Email,
        string FullName,
        string Bio,
        string ProfilePicture,
        string Website,
        DateTime BirthDate,
        int FollowersCount,
        int FollowingCount,
        bool IsVerified,
        DateTime LastActive
    )
    {
        public ICollection<ResultBlockUserDto>? BlockedUsers { get; set; }
        public ICollection<ResultBlockUserDto>? BlockingUsers { get; set; }
        public ICollection<ResultPostDto>? Posts { get; set; }
        public ICollection<ResultFollowDto>? Followers { get; set; }
        public ICollection<ResultFollowDto>? Followings { get; set; }
        public ICollection<ResultLikeDto>? Likes { get; set; }
        public ICollection<ResultCommentDto>? Comments { get; set; }
        public ICollection<ResultMessageDto>? SentMessages { get; set; }
        public ICollection<ResultMessageDto>? ReceivedMessages { get; set; }
        public ICollection<ResultNotificationDto>? Notifications { get; set; }
        public ICollection<ResultMediaDto>? Medias { get; set; }
        public ICollection<ResultStoryDto>? Stories { get; set; }
        public ICollection<ResultSavedPostDto>? SavedPosts { get; set; }
        public ICollection<ResultReportCommentDto>? ReportComments { get; set; }
        public ICollection<ResultViewStoryDto>? ViewStories { get; set; }
        public ICollection<ResultUserSettingDto>? UserSettings { get; set; }
        public ICollection<ResultUserDto>? SearchedBy { get; set; }
        public ICollection<ResultRecentChatsDto>? RecentChats { get; set; }
        public ResultNoteDto? Note { get; set; }
        public ICollection<ResultReactionDto>? Reactions { get; set; }
        public ICollection<ResultPostDto>? TaggedPosts { get; set; }
    }
}