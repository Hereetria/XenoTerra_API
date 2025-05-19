

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
    public record class ResultUserWithRelationsPrivateDto
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

        public ICollection<ResultBlockUserDto> BlockedUsers { get; init; } = [];
        public ICollection<ResultBlockUserDto> BlockingUsers { get; init; } = [];
        public ICollection<ResultPostDto> Posts { get; init; } = [];
        public ICollection<ResultFollowDto> Followers { get; init; } = [];
        public ICollection<ResultFollowDto> Followings { get; init; } = [];
        public ICollection<User> Users { get; init; } = [];
        public ICollection<ResultLikeDto> Likes { get; init; } = [];
        public ICollection<ResultCommentDto> Comments { get; init; } = [];
        public ICollection<ResultMessageDto> SentMessages { get; init; } = [];
        public ICollection<ResultMessageDto> ReceivedMessages { get; init; } = [];
        public ICollection<ResultNotificationDto> Notifications { get; init; } = [];
        public ICollection<ResultMediaDto> Medias { get; init; } = [];
        public ICollection<ResultStoryDto> Stories { get; init; } = [];
        public ICollection<ResultSavedPostDto> SavedPosts { get; init; } = [];
        public ICollection<ResultReportCommentDto> ReportComments { get; init; } = [];
        public ICollection<ResultViewStoryDto> ViewStories { get; init; } = [];
        public ICollection<ResultUserSettingDto> UserSettings { get; init; } = [];
        public ICollection<ResultUserPrivateDto> SearchedBy { get; init; } = [];
        public ICollection<ResultRecentChatsDto> RecentChats { get; init; } = [];
        public ResultNoteDto Note { get; init; } = new();
        public ICollection<ResultReactionDto> Reactions { get; init; } = [];
        public ICollection<ResultPostDto> TaggedPosts { get; init; } = [];
    }
}