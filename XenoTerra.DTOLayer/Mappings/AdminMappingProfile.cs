using AutoMapper;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.AuthDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.AppRoleDtos.Admin;
using XenoTerra.DTOLayer.Dtos.StoryDtos.Admin;
using XenoTerra.DTOLayer.Dtos.HighlightDtos.Admin;
using XenoTerra.DTOLayer.Dtos.NoteDtos.Admin;
using XenoTerra.DTOLayer.Dtos.RecentChatsDtos.Admin;
using XenoTerra.DTOLayer.Dtos.MessageDtos.Admin;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.PostLikeDtos.Admin;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos.Admin;
using XenoTerra.DTOLayer.Dtos.CommentDtos.Admin;
using XenoTerra.DTOLayer.Dtos.UserSettingDtos.Admin;
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos.Admin;
using XenoTerra.DTOLayer.Dtos.UserPostTagDtos.Admin;
using XenoTerra.DTOLayer.Dtos.SavedPostDtos.Admin;
using XenoTerra.DTOLayer.Dtos.PostDtos.Admin;
using XenoTerra.DTOLayer.Dtos.ReportStoryDtos.Admin;
using XenoTerra.DTOLayer.Dtos.CommentLikeDtos.Admin;
using XenoTerra.DTOLayer.Dtos.NotificationDtos.Admin;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos.Admin;
using XenoTerra.DTOLayer.Dtos.StoryLikeDtos.Admin;
using XenoTerra.DTOLayer.Dtos.ReactionDtos.Admin;
using XenoTerra.DTOLayer.Dtos.MediaDtos.Admin;
using XenoTerra.DTOLayer.Dtos.FollowDtos.Admin;

namespace XenoTerra.DTOLayer.Mappings
{
    public class AdminMappingProfile : Profile
    {
        public AdminMappingProfile()
        {
            // Role
            CreateMap<AppRole, ResultAppRoleWithRelationsAdminDto>().ReverseMap();
            CreateMap<AppRole, ResultAppRoleAdminDto>().ReverseMap();
            CreateMap<AppRole, CreateAppRoleAdminDto>().ReverseMap();
            CreateMap<AppRole, UpdateAppRoleAdminDto>().ReverseMap();

            // AppUser
            CreateMap<AppUser, ResultAppUserWithRelationsAdminDto>()
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
                .ForMember(dest => dest.WasSearchedBy, opt => opt.MapFrom(src => src.WasSearchedBy))
                .ForMember(dest => dest.RecentChats, opt => opt.MapFrom(src => src.RecentChats))
                .ForMember(dest => dest.Note, opt => opt.MapFrom(src => src.Note))
                .ForMember(dest => dest.TaggedPosts, opt => opt.MapFrom(src => src.TaggedPosts))
                .ReverseMap();

            CreateMap<AppUser, ResultAppUserAdminDto>().ReverseMap();
            CreateMap<AppUser, RegisterDto>().ReverseMap();
            CreateMap<AppUser, UpdateAppUserAdminDto>().ReverseMap();

            // BlockUser
            CreateMap<BlockUser, ResultBlockUserWithRelationsAdminDto>()
                .ForMember(dest => dest.BlockingUser, opt => opt.MapFrom(src => src.BlockingUser ?? null))
                .ForMember(dest => dest.BlockedUser, opt => opt.MapFrom(src => src.BlockedUser ?? null))
                .ReverseMap();
            CreateMap<BlockUser, ResultBlockUserAdminDto>().ReverseMap();
            CreateMap<BlockUser, CreateBlockUserAdminDto>().ReverseMap();
            CreateMap<BlockUser, UpdateBlockUserAdminDto>().ReverseMap();

            // Comment
            CreateMap<Comment, ResultCommentWithRelationsAdminDto>()
                .ForMember(dest => dest.User, (IMemberConfigurationExpression<Comment, ResultCommentWithRelationsAdminDto, object> opt) => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.CommentLikes, opt => opt.MapFrom(src => src.CommentLikes))
                .ForMember(dest => dest.ParentComment, opt => opt.MapFrom(src => src.ParentComment))
                .ReverseMap();
            CreateMap<Comment, ResultCommentAdminDto>().ReverseMap();
            CreateMap<Comment, CreateCommentAdminDto>().ReverseMap();
            CreateMap<Comment, UpdateCommentAdminDto>().ReverseMap();

            // CommentLike
            CreateMap<CommentLike, CreateCommentLikeAdminDto>().ReverseMap();
            CreateMap<CommentLike, ResultCommentLikeAdminDto>().ReverseMap();
            CreateMap<CommentLike, ResultCommentLikeWithRelationsAdminDto>().ReverseMap()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment))
                .ReverseMap();
            CreateMap<CommentLike, UpdateCommentLikeAdminDto>().ReverseMap();

            // Follow
            CreateMap<Follow, ResultFollowWithRelationsAdminDto>()
                .ForMember(dest => dest.Follower, opt => opt.MapFrom(src => src.Follower))
                .ForMember(dest => dest.Following, opt => opt.MapFrom(src => src.Following))
                .ReverseMap();
            CreateMap<Follow, ResultFollowAdminDto>().ReverseMap();
            CreateMap<Follow, CreateFollowAdminDto>().ReverseMap();
            CreateMap<Follow, UpdateFollowAdminDto>().ReverseMap();

            // Highlight
            CreateMap<Highlight, ResultHighlightWithRelationsAdminDto>()
                .ForMember(dest => dest.Stories, opt => opt.MapFrom(src => src.StoryHighlights.Select(sh => sh.Story)))
                .ReverseMap();
            CreateMap<Highlight, ResultHighlightAdminDto>().ReverseMap();
            CreateMap<Highlight, CreateHighlightAdminDto>().ReverseMap();
            CreateMap<Highlight, UpdateHighlightAdminDto>().ReverseMap();

            // Media
            CreateMap<Media, ResultMediaWithRelationsAdminDto>()
                .ForMember(dest => dest.Sender, opt => opt.MapFrom(src => src.Sender))
                .ForMember(dest => dest.Receiver, opt => opt.MapFrom(src => src.Receiver))
                .ReverseMap();
            CreateMap<Media, ResultMediaAdminDto>().ReverseMap();
            CreateMap<Media, CreateMediaAdminDto>().ReverseMap();
            CreateMap<Media, UpdateMediaAdminDto>().ReverseMap();

            // Message
            CreateMap<Message, ResultMessageWithRelationsAdminDto>()
                .ForMember(dest => dest.Sender, opt => opt.MapFrom(src => src.Sender))
                .ForMember(dest => dest.Receiver, opt => opt.MapFrom(src => src.Receiver))
                .ReverseMap();
            CreateMap<Message, ResultMessageAdminDto>().ReverseMap();
            CreateMap<Message, CreateMessageAdminDto>().ReverseMap();
            CreateMap<Message, UpdateMessageAdminDto>().ReverseMap();

            // Note
            CreateMap<Note, ResultNoteWithRelationsAdminDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ReverseMap();
            CreateMap<Note, ResultNoteAdminDto>().ReverseMap();
            CreateMap<Note, CreateNoteAdminDto>().ReverseMap();
            CreateMap<Note, UpdateNoteAdminDto>().ReverseMap();

            // Notification
            CreateMap<Notification, ResultNotificationWithRelationsAdminDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ReverseMap();
            CreateMap<Notification, ResultNotificationAdminDto>().ReverseMap();
            CreateMap<Notification, CreateNotificationAdminDto>().ReverseMap();
            CreateMap<Notification, UpdateNotificationAdminDto>().ReverseMap();

            // Post
            CreateMap<Post, ResultPostWithRelationsAdminDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Likes, opt => opt.MapFrom(src => src.Likes))
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments))
                .ForMember(dest => dest.SavedPosts, opt => opt.MapFrom(src => src.SavedPosts))
                .ForMember(dest => dest.TaggedUsers, opt => opt.MapFrom(src => src.TaggedUsers))
                .ForMember(dest => dest.ReportPosts, opt => opt.MapFrom(src => src.ReportPosts))
                .ReverseMap();
            CreateMap<Post, ResultPostAdminDto>().ReverseMap();
            CreateMap<Post, CreatePostAdminDto>().ReverseMap();
            CreateMap<Post, UpdatePostAdminDto>().ReverseMap();

            // PostLike
            CreateMap<PostLike, ResultPostLikeWithRelationsAdminDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Post, opt => opt.MapFrom(src => src.Post))
                .ReverseMap();
            CreateMap<PostLike, ResultPostLikeAdminDto>().ReverseMap();
            CreateMap<PostLike, CreatePostLikeAdminDto>().ReverseMap();
            CreateMap<PostLike, UpdatePostLikeAdminDto>().ReverseMap();

            // Reaction
            CreateMap<Reaction, ResultReactionWithRelationsAdminDto>()
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message))
                .ReverseMap();
            CreateMap<Reaction, ResultReactionAdminDto>().ReverseMap();
            CreateMap<Reaction, CreateReactionAdminDto>().ReverseMap();
            CreateMap<Reaction, UpdateReactionAdminDto>().ReverseMap();

            // RecentChats
            CreateMap<RecentChats, ResultRecentChatsWithRelationsAdminDto>()
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users))
                .ReverseMap();
            CreateMap<RecentChats, ResultRecentChatsAdminDto>().ReverseMap();
            CreateMap<RecentChats, CreateRecentChatsAdminDto>().ReverseMap();
            CreateMap<RecentChats, UpdateRecentChatsAdminDto>().ReverseMap();

            // ReportComment
            CreateMap<ReportComment, ResultReportCommentWithRelationsAdminDto>()
                .ForMember(dest => dest.ReporterUser, opt => opt.MapFrom(src => src.ReporterUser))
                .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment))
                .ReverseMap();
            CreateMap<ReportComment, ResultReportCommentAdminDto>().ReverseMap();
            CreateMap<ReportComment, CreateReportCommentAdminDto>().ReverseMap();
            CreateMap<ReportComment, UpdateReportCommentAdminDto>().ReverseMap();

            // ReportStory
            CreateMap<ReportStory, ResultReportStoryWithRelationsAdminDto>()
                .ForMember(dest => dest.ReporterUser, opt => opt.MapFrom(src => src.ReporterUser))
                .ForMember(dest => dest.Story, opt => opt.MapFrom(src => src.Story))
                .ReverseMap();
            CreateMap<ReportStory, ResultReportStoryAdminDto>().ReverseMap();
            CreateMap<ReportStory, CreateReportStoryAdminDto>().ReverseMap();
            CreateMap<ReportStory, UpdateReportStoryAdminDto>().ReverseMap();

            // SavedPost
            CreateMap<SavedPost, ResultSavedPostWithRelationsAdminDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Post, opt => opt.MapFrom(src => src.Post))
                .ReverseMap();
            CreateMap<SavedPost, ResultSavedPostAdminDto>().ReverseMap();
            CreateMap<SavedPost, CreateSavedPostAdminDto>().ReverseMap();
            CreateMap<SavedPost, UpdateSavedPostAdminDto>().ReverseMap();

            // SearchHistory
            CreateMap<SearchHistory, ResultSearchHistoryWithRelationsAdminDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.SearchedUsers, opt => opt.MapFrom(src => src.SearchedUsers))
                .ReverseMap();
            CreateMap<SearchHistory, ResultSearchHistoryAdminDto>().ReverseMap();
            CreateMap<SearchHistory, CreateSearchHistoryAdminDto>().ReverseMap();
            CreateMap<SearchHistory, UpdateSearchHistoryAdminDto>().ReverseMap();

            // Story
            CreateMap<Story, ResultStoryWithRelationsAdminDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.ViewStories, opt => opt.MapFrom(src => src.ViewStories))
                .ForMember(dest => dest.Highlights, opt => opt.MapFrom(src => src.StoryHighlights.Select(sh => sh.Highlight)))
                .ForMember(dest => dest.StoryLikes, opt => opt.MapFrom(src => src.StoryLikes))
                .ForMember(dest => dest.ReportStories, opt => opt.MapFrom(src => src.ReportStories))
                .ReverseMap();
            CreateMap<Story, ResultStoryAdminDto>().ReverseMap();
            CreateMap<Story, CreateStoryAdminDto>().ReverseMap();
            CreateMap<Story, UpdateStoryAdminDto>().ReverseMap();

            // StoryLike
            CreateMap<StoryLike, ResultStoryLikeWithRelationsAdminDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Story, opt => opt.MapFrom(src => src.Story))
                .ReverseMap();
            CreateMap<StoryLike, ResultStoryLikeAdminDto>().ReverseMap();
            CreateMap<StoryLike, CreateStoryLikeAdminDto>().ReverseMap();
            CreateMap<StoryLike, UpdateStoryLikeAdminDto>().ReverseMap();

            // UserPostTag
            CreateMap<UserPostTag, ResultUserPostTagWithRelationsAdminDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Post, opt => opt.MapFrom(src => src.Post))
                .ReverseMap();
            CreateMap<UserPostTag, ResultUserPostTagAdminDto>().ReverseMap();
            CreateMap<UserPostTag, CreateUserPostTagAdminDto>().ReverseMap();
            CreateMap<UserPostTag, UpdateUserPostTagAdminDto>().ReverseMap();

            // UserSetting
            CreateMap<UserSetting, ResultUserSettingWithRelationsAdminDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ReverseMap();
            CreateMap<UserSetting, ResultUserSettingAdminDto>().ReverseMap();
            CreateMap<UserSetting, CreateUserSettingAdminDto>().ReverseMap();
            CreateMap<UserSetting, UpdateUserSettingAdminDto>().ReverseMap();

            // ViewStory
            CreateMap<ViewStory, ResultViewStoryWithRelationsAdminDto>()
                .ForMember(dest => dest.Story, opt => opt.MapFrom(src => src.Story))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ReverseMap();
            CreateMap<ViewStory, ResultViewStoryAdminDto>().ReverseMap();
            CreateMap<ViewStory, CreateViewStoryAdminDto>().ReverseMap();
            CreateMap<ViewStory, UpdateViewStoryAdminDto>().ReverseMap();
        }
    }
}
