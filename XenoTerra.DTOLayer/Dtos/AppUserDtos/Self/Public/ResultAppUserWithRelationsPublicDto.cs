using XenoTerra.DTOLayer.Dtos.CommentDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.CommentDtos.Self.Public;
using XenoTerra.DTOLayer.Dtos.FollowDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.FollowDtos.Self.Public;
using XenoTerra.DTOLayer.Dtos.HighlightDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.HighlightDtos.Self.Public;
using XenoTerra.DTOLayer.Dtos.MediaDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.MessageDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.NoteDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.NoteDtos.Self.Public;
using XenoTerra.DTOLayer.Dtos.NotificationDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.PostDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.PostDtos.Self.Public;
using XenoTerra.DTOLayer.Dtos.PostLikeDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.PostLikeDtos.Self.Public;
using XenoTerra.DTOLayer.Dtos.RecentChatsDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.ReportPostDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.ReportStoryDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.SavedPostDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.StoryDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.StoryDtos.Self.Public;
using XenoTerra.DTOLayer.Dtos.StoryLikeDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.UserPostTagDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.UserPostTagDtos.Self.Public;
using XenoTerra.DTOLayer.Dtos.UserSettingDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos.Self.Own;

namespace XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Public
{
    public class ResultAppUserWithRelationsPublicDto
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

        public ICollection<ResultPostPublicDto> Posts { get; set; } = [];

        public ICollection<ResultFollowPublicDto> Followers { get; set; } = [];

        public ICollection<ResultFollowPublicDto> Followings { get; set; } = [];

        public ICollection<ResultPostLikePublicDto> PostLikes { get; set; } = [];

        public ICollection<ResultCommentPublicDto> Comments { get; set; } = [];

        public ICollection<ResultHighlightPublicDto> Highlights { get; set; } = [];

        public ICollection<ResultStoryPublicDto> Stories { get; set; } = [];

        public ResultNotePublicDto Note { get; set; } = null!;

        public ICollection<ResultUserPostTagPublicDto> TaggedPosts { get; set; } = [];
    }
}