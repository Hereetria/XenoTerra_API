
using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.MediaDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.NoteDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.StoryDtos.Self.Public;
using XenoTerra.DTOLayer.Dtos.StoryDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.HighlightDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.MessageDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.StoryLikeDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.PostDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.ReportPostDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.RecentChatsDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.FollowDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.ReactionDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.UserPostTagDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.CommentDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.PostDtos.Self.Public;
using XenoTerra.DTOLayer.Dtos.SavedPostDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.UserSettingDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.NotificationDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.StoryHighlightDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.PostLikeDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.ReportStoryDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.PostLikeDtos.Self.Public;
using XenoTerra.DTOLayer.Dtos.HighlightDtos.Self.Public;
using XenoTerra.DTOLayer.Dtos.CommentLikeDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.CommentDtos.Self.Public;
using XenoTerra.DTOLayer.Dtos.UserPostTagDtos.Self.Public;
using XenoTerra.DTOLayer.Dtos.FollowDtos.Self.Public;
using XenoTerra.DTOLayer.Dtos.CommentLikeDtos.Self.Public;
using XenoTerra.DTOLayer.Dtos.NoteDtos.Self.Public;
using XenoTerra.DTOLayer.Dtos.AppRoleDtos.Admin;
using XenoTerra.DTOLayer.Dtos.AuthDtos;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Public;

namespace XenoTerra.DTOLayer.Mappings
{
    public class SelfMappingProfile : Profile
    {
        public SelfMappingProfile()
        {
            // AppUser
            CreateMap<AppUser, ResultAppUserWithRelationsOwnDto>()
                .ForMember(dest => dest.Posts, opt => opt.MapFrom(src => src.Posts))
                .ForMember(dest => dest.Followers, opt => opt.MapFrom(src => src.Followers))
                .ForMember(dest => dest.Followings, opt => opt.MapFrom(src => src.Followings))
                .ForMember(dest => dest.PostLikes, opt => opt.MapFrom(src => src.PostLikes))
                .ForMember(dest => dest.StoryLikes, opt => opt.MapFrom(src => src.StoryLikes))
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments))
                .ForMember(dest => dest.SentMessages, opt => opt.MapFrom(src => src.SentMessages))
                .ForMember(dest => dest.ReceivedMessages, opt => opt.MapFrom(src => src.ReceivedMessages))
                .ForMember(dest => dest.Notifications, opt => opt.MapFrom(src => src.Notifications))
                .ForMember(dest => dest.Stories, opt => opt.MapFrom(src => src.Stories))
                .ForMember(dest => dest.SavedPosts, opt => opt.MapFrom(src => src.SavedPosts))
                .ForMember(dest => dest.ReportComments, opt => opt.MapFrom(src => src.ReportComments))
                .ForMember(dest => dest.ViewStories, opt => opt.MapFrom(src => src.ViewStories))
                .ForMember(dest => dest.PerformedSearches, opt => opt.MapFrom(src => src.PerformedSearches))
                .ForMember(dest => dest.RecentChats, opt => opt.MapFrom(src => src.RecentChats))
                .ForMember(dest => dest.Note, opt => opt.MapFrom(src => src.Note))
                .ForMember(dest => dest.TaggedPosts, opt => opt.MapFrom(src => src.TaggedPosts))
                .ReverseMap();

            CreateMap<AppUser, ResultAppUserWithRelationsPublicDto>()
                .ForMember(dest => dest.Posts, opt => opt.MapFrom(src => src.Posts))
                .ForMember(dest => dest.Followers, opt => opt.MapFrom(src => src.Followers))
                .ForMember(dest => dest.Followings, opt => opt.MapFrom(src => src.Followings))
                .ForMember(dest => dest.PostLikes, opt => opt.MapFrom(src => src.PostLikes))
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments))
                .ForMember(dest => dest.Stories, opt => opt.MapFrom(src => src.Stories))
                .ForMember(dest => dest.Note, opt => opt.MapFrom(src => src.Note))
                .ForMember(dest => dest.TaggedPosts, opt => opt.MapFrom(src => src.TaggedPosts))
                .ReverseMap();

            CreateMap<AppUser, ResultAppUserOwnDto>().ReverseMap();
            CreateMap<AppUser, RegisterDto>().ReverseMap();
            CreateMap<AppUser, UpdateAppUserOwnDto>().ReverseMap();
            CreateMap<AppUser, ResultAppUserPublicDto>().ReverseMap();

            // BlockUser
            CreateMap<BlockUser, CreateBlockUserOwnDto>().ReverseMap();
            CreateMap<BlockUser, ResultBlockUserOwnDto>().ReverseMap();
            CreateMap<BlockUser, ResultBlockUserWithRelationsOwnDto>()
                .ForMember(dest => dest.BlockingUser, opt => opt.MapFrom(src => src.BlockingUser ?? null))
                .ForMember(dest => dest.BlockedUser, opt => opt.MapFrom(src => src.BlockedUser ?? null))
                .ReverseMap();
            CreateMap<BlockUser, UpdateBlockUserOwnDto>().ReverseMap();

            // Comment
            CreateMap<Comment, CreateCommentOwnDto>().ReverseMap();
            CreateMap<Comment, ResultCommentOwnDto>().ReverseMap();
            CreateMap<Comment, ResultCommentWithRelationsOwnDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.CommentLikes, opt => opt.MapFrom(src => src.CommentLikes))
                .ForMember(dest => dest.ParentComment, opt => opt.MapFrom(src => src.ParentComment))
                .ReverseMap();
            CreateMap<Comment, ResultCommentWithRelationsPublicDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.CommentLikes, opt => opt.MapFrom(src => src.CommentLikes))
                .ForMember(dest => dest.ParentComment, opt => opt.MapFrom(src => src.ParentComment))
                .ReverseMap();
            CreateMap<Comment, UpdateCommentOwnDto>().ReverseMap();
            CreateMap<Comment, ResultCommentPublicDto>().ReverseMap();

            // CommentLike
            CreateMap<CommentLike, CreateCommentLikeOwnDto>().ReverseMap();
            CreateMap<CommentLike, ResultCommentLikeOwnDto>().ReverseMap();
            CreateMap<CommentLike, ResultCommentLikeWithRelationsOwnDto>().ReverseMap()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment))
                .ReverseMap();
            CreateMap<CommentLike, ResultCommentLikeWithRelationsPublicDto>().ReverseMap()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment))
                .ReverseMap();
            CreateMap<CommentLike, UpdateCommentLikeOwnDto>().ReverseMap();
            CreateMap<CommentLike, ResultCommentLikePublicDto>().ReverseMap();

            // Follow
            CreateMap<Follow, CreateFollowOwnDto>().ReverseMap();
            CreateMap<Follow, ResultFollowOwnDto>().ReverseMap();
            CreateMap<Follow, ResultFollowWithRelationsOwnDto>()
                .ForMember(dest => dest.Follower, opt => opt.MapFrom(src => src.Follower))
                .ForMember(dest => dest.Following, opt => opt.MapFrom(src => src.Following))
                .ReverseMap();
            CreateMap<Follow, ResultFollowWithRelationsPublicDto>()
                .ForMember(dest => dest.Follower, opt => opt.MapFrom(src => src.Follower))
                .ForMember(dest => dest.Following, opt => opt.MapFrom(src => src.Following))
                .ReverseMap();
            CreateMap<Follow, UpdateFollowOwnDto>().ReverseMap();
            CreateMap<Follow, ResultFollowPublicDto>().ReverseMap();

            // Highlight
            CreateMap<Highlight, CreateHighlightOwnDto>().ReverseMap();
            CreateMap<Highlight, ResultHighlightOwnDto>().ReverseMap();
            CreateMap<Highlight, ResultHighlightWithRelationsOwnDto>()
                .ForMember(dest => dest.Stories, opt => opt.MapFrom(src => src.StoryHighlights.Select(sh => sh.Story)))
                .ReverseMap();
            CreateMap<Highlight, ResultHighlightWithRelationsPublicDto>()
                .ForMember(dest => dest.Stories, opt => opt.MapFrom(src => src.StoryHighlights.Select(sh => sh.Story)))
                .ReverseMap();
            CreateMap<Highlight, UpdateHighlightOwnDto>().ReverseMap();
            CreateMap<Highlight, ResultHighlightPublicDto>().ReverseMap();

            // Media
            CreateMap<Media, CreateMediaOwnDto>().ReverseMap();
            CreateMap<Media, ResultMediaOwnDto>().ReverseMap();
            CreateMap<Media, ResultMediaWithRelationsOwnDto>()
                .ForMember(dest => dest.Sender, opt => opt.MapFrom(src => src.Sender))
                .ForMember(dest => dest.Receiver, opt => opt.MapFrom(src => src.Receiver))
                .ReverseMap();
            CreateMap<Media, UpdateMediaOwnDto>().ReverseMap();

            // Message
            CreateMap<Message, CreateMessageOwnDto>().ReverseMap();
            CreateMap<Message, ResultMessageOwnDto>().ReverseMap();
            CreateMap<Message, ResultMessageWithRelationsOwnDto>()
                .ForMember(dest => dest.Sender, opt => opt.MapFrom(src => src.Sender))
                .ForMember(dest => dest.Receiver, opt => opt.MapFrom(src => src.Receiver))
                .ReverseMap();
            CreateMap<Message, UpdateMessageOwnDto>().ReverseMap();

            // Note
            CreateMap<Note, CreateNoteOwnDto>().ReverseMap();
            CreateMap<Note, ResultNoteOwnDto>().ReverseMap();
            CreateMap<Note, ResultNoteWithRelationsOwnDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ReverseMap();
            CreateMap<Note, ResultNoteWithRelationsPublicDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ReverseMap();
            CreateMap<Note, UpdateNoteOwnDto>().ReverseMap();
            CreateMap<Note, ResultNotePublicDto>().ReverseMap();

            // Notification
            CreateMap<Notification, CreateNotificationOwnDto>().ReverseMap();
            CreateMap<Notification, ResultNotificationOwnDto>().ReverseMap();
            CreateMap<Notification, ResultNotificationWithRelationsOwnDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ReverseMap();
            CreateMap<Notification, UpdateNotificationOwnDto>().ReverseMap();

            // Post
            CreateMap<Post, CreatePostOwnDto>().ReverseMap();
            CreateMap<Post, ResultPostOwnDto>().ReverseMap();
            CreateMap<Post, ResultPostWithRelationsOwnDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Likes, opt => opt.MapFrom(src => src.Likes))
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments))
                .ForMember(dest => dest.TaggedUsers, opt => opt.MapFrom(src => src.TaggedUsers))
                .ReverseMap();
            CreateMap<Post, ResultPostWithRelationsPublicDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Likes, opt => opt.MapFrom(src => src.Likes))
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments))
                .ForMember(dest => dest.TaggedUsers, opt => opt.MapFrom(src => src.TaggedUsers))
                .ReverseMap();
            CreateMap<Post, UpdatePostOwnDto>().ReverseMap();
            CreateMap<Post, ResultPostPublicDto>().ReverseMap();

            // PostLike
            CreateMap<PostLike, CreatePostLikeOwnDto>().ReverseMap();
            CreateMap<PostLike, ResultPostLikeOwnDto>().ReverseMap();
            CreateMap<PostLike, ResultPostLikeWithRelationsOwnDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Post, opt => opt.MapFrom(src => src.Post))
                .ReverseMap();
            CreateMap<PostLike, ResultPostLikeWithRelationsPublicDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Post, opt => opt.MapFrom(src => src.Post))
                .ReverseMap();
            CreateMap<PostLike, UpdatePostLikeOwnDto>().ReverseMap();
            CreateMap<PostLike, ResultPostLikePublicDto>().ReverseMap();

            // Reaction
            CreateMap<Reaction, CreateReactionOwnDto>().ReverseMap();
            CreateMap<Reaction, ResultReactionOwnDto>().ReverseMap();
            CreateMap<Reaction, ResultReactionWithRelationsOwnDto>()
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message))
                .ReverseMap();
            CreateMap<Reaction, UpdateReactionOwnDto>().ReverseMap();

            // RecentChats
            CreateMap<RecentChats, CreateRecentChatsOwnDto>().ReverseMap();
            CreateMap<RecentChats, ResultRecentChatsOwnDto>().ReverseMap();
            CreateMap<RecentChats, ResultRecentChatsWithRelationsOwnDto>()
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users))
                .ReverseMap();
            CreateMap<RecentChats, UpdateRecentChatsOwnDto>().ReverseMap();

            // ReportComment
            CreateMap<ReportComment, CreateReportCommentOwnDto>().ReverseMap();
            CreateMap<ReportComment, ResultReportCommentOwnDto>().ReverseMap();
            CreateMap<ReportComment, ResultReportCommentWithRelationsOwnDto>()
                .ForMember(dest => dest.ReporterUser, opt => opt.MapFrom(src => src.ReporterUser))
                .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment))
                .ReverseMap();
            CreateMap<ReportComment, UpdateReportCommentOwnDto>().ReverseMap();

            // ReportPost
            CreateMap<ReportPost, CreateReportPostOwnDto>().ReverseMap();
            CreateMap<ReportPost, ResultReportPostOwnDto>().ReverseMap();
            CreateMap<ReportPost, ResultReportPostWithRelationsOwnDto>()
                .ForMember(dest => dest.ReporterUser, opt => opt.MapFrom(src => src.ReporterUser))
                .ForMember(dest => dest.Post, opt => opt.MapFrom(src => src.Post))
                .ReverseMap();
            CreateMap<ReportPost, UpdateReportPostOwnDto>().ReverseMap();

            // ReportStory
            CreateMap<ReportStory, CreateReportStoryOwnDto>().ReverseMap();
            CreateMap<ReportStory, ResultReportStoryOwnDto>().ReverseMap();
            CreateMap<ReportStory, ResultReportStoryWithRelationsOwnDto>()
                .ForMember(dest => dest.ReporterUser, opt => opt.MapFrom(src => src.ReporterUser))
                .ForMember(dest => dest.Story, opt => opt.MapFrom(src => src.Story))
                .ReverseMap();
            CreateMap<ReportStory, UpdateReportStoryOwnDto>().ReverseMap();

            // SavedPost
            CreateMap<SavedPost, CreateSavedPostOwnDto>().ReverseMap();
            CreateMap<SavedPost, ResultSavedPostOwnDto>().ReverseMap();
            CreateMap<SavedPost, ResultSavedPostWithRelationsOwnDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Post, opt => opt.MapFrom(src => src.Post))
                .ReverseMap();
            CreateMap<SavedPost, UpdateSavedPostOwnDto>().ReverseMap();

            // SearchHistory
            CreateMap<SearchHistory, CreateSearchHistoryOwnDto>().ReverseMap();
            CreateMap<SearchHistory, ResultSearchHistoryOwnDto>().ReverseMap();
            CreateMap<SearchHistory, ResultSearchHistoryWithRelationsOwnDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.SearchedUsers, opt => opt.MapFrom(src => src.SearchedUsers))
                .ReverseMap();
            CreateMap<SearchHistory, UpdateSearchHistoryOwnDto>().ReverseMap();

            // Story
            CreateMap<Story, CreateStoryOwnDto>().ReverseMap();
            CreateMap<Story, ResultStoryOwnDto>().ReverseMap();
            CreateMap<Story, ResultStoryWithRelationsOwnDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.ViewStories, opt => opt.MapFrom(src => src.ViewStories))
                .ForMember(dest => dest.Highlights, opt => opt.MapFrom(src => src.StoryHighlights.Select(sh => sh.Highlight)))
                .ForMember(dest => dest.StoryLikes, opt => opt.MapFrom(src => src.StoryLikes))
                .ReverseMap();
            CreateMap<Story, ResultStoryWithRelationsPublicDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Highlights, opt => opt.MapFrom(src => src.StoryHighlights.Select(sh => sh.Highlight)))
                .ReverseMap();
            CreateMap<Story, ResultStoryPublicDto>().ReverseMap();

            // StoryHighlight
            CreateMap<StoryLike, ResultStoryLikeWithRelationsOwnDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Story, opt => opt.MapFrom(src => src.Story))
                .ReverseMap();
            CreateMap<StoryHighlight, CreateStoryHighlightOwnDto>().ReverseMap();
            CreateMap<StoryHighlight, ResultStoryHighlightOwnDto>().ReverseMap();
            CreateMap<StoryHighlight, UpdateStoryHighlightOwnDto>().ReverseMap();

            // StoryLike
            CreateMap<StoryLike, CreateStoryLikeOwnDto>().ReverseMap();
            CreateMap<StoryLike, ResultStoryLikeOwnDto>().ReverseMap();
            CreateMap<StoryLike, ResultStoryLikeWithRelationsOwnDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Story, opt => opt.MapFrom(src => src.Story))
                .ReverseMap();
            CreateMap<StoryLike, UpdateStoryLikeOwnDto>().ReverseMap();

            // UserPostTag
            CreateMap<UserPostTag, ResultUserPostTagWithRelationsOwnDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Post, opt => opt.MapFrom(src => src.Post))
                .ReverseMap();
            CreateMap<UserPostTag, ResultUserPostTagWithRelationsPublicDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Post, opt => opt.MapFrom(src => src.Post))
                .ReverseMap();
            CreateMap<UserPostTag, CreateUserPostTagOwnDto>().ReverseMap();
            CreateMap<UserPostTag, ResultUserPostTagOwnDto>().ReverseMap();
            CreateMap<UserPostTag, UpdateUserPostTagOwnDto>().ReverseMap();
            CreateMap<UserPostTag, ResultUserPostTagPublicDto>().ReverseMap();

            // UserSetting
            CreateMap<UserSetting, CreateUserSettingOwnDto>().ReverseMap();
            CreateMap<UserSetting, ResultUserSettingOwnDto>().ReverseMap();
            CreateMap<UserSetting, ResultUserSettingWithRelationsOwnDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ReverseMap();
            CreateMap<UserSetting, UpdateUserSettingOwnDto>().ReverseMap();

            // ViewStory
            CreateMap<ViewStory, ResultViewStoryWithRelationsOwnDto>()
                .ForMember(dest => dest.Story, opt => opt.MapFrom(src => src.Story))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ReverseMap();
            CreateMap<ViewStory, CreateViewStoryOwnDto>().ReverseMap();
            CreateMap<ViewStory, ResultViewStoryOwnDto>().ReverseMap();
            CreateMap<ViewStory, UpdateViewStoryOwnDto>().ReverseMap();
        }
    }
}