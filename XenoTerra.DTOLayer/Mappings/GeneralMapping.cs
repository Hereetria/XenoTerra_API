
using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;
using XenoTerra.DTOLayer.Dtos.AuthDtos;
using XenoTerra.DTOLayer.Dtos.CommentAdminDtos.Admin;
using XenoTerra.DTOLayer.Dtos.StoryAdminDtos.Admin;
using XenoTerra.DTOLayer.Dtos.ViewStoryAdminDtos.Admin;
using XenoTerra.DTOLayer.Dtos.HighlightAdminDtos.Admin;
using XenoTerra.DTOLayer.Dtos.SearchHistoryAdminDtos.Admin;
using XenoTerra.DTOLayer.Dtos.PostAdminDtos.Admin;
using XenoTerra.DTOLayer.Dtos.PostLikeAdminDtos.Admin;
using XenoTerra.DTOLayer.Dtos.ReportStoryAdminDtos.Admin;
using XenoTerra.DTOLayer.Dtos.ReactionAdminDtos.Admin;
using XenoTerra.DTOLayer.Dtos.MediaAdminDtos.Admin;
using XenoTerra.DTOLayer.Dtos.UserSettingAdminDtos.Admin;
using XenoTerra.DTOLayer.Dtos.NotificationAdminDtos.Admin;
using XenoTerra.DTOLayer.Dtos.MessageAdminDtos.Admin;
using XenoTerra.DTOLayer.Dtos.BlockUserAdminDtos.Admin;
using XenoTerra.DTOLayer.Dtos.ReportCommentAdminDtos.Admin;
using XenoTerra.DTOLayer.Dtos.FollowAdminDtos.Admin;
using XenoTerra.DTOLayer.Dtos.RecentChatsAdminDtos.Admin;
using XenoTerra.DTOLayer.Dtos.AppRoleDtos.Admin;
using XenoTerra.DTOLayer.Dtos.NoteAdminDtos.Admin;
using XenoTerra.DTOLayer.Dtos.SavedPostAdminDtos.Admin;
using XenoTerra.DTOLayer.Dtos.StoryLikeAdminDtos.Admin;

namespace XenoTerra.DTOLayer.Mappings
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            // BlockUser Mappings
            CreateMap<BlockUser, ResultBlockUserWithRelationsAdminDto>()
                .ForMember(dest => dest.BlockingUser, opt => opt.MapFrom(src => src.BlockingUser ?? null))
                .ForMember(dest => dest.BlockedUser, opt => opt.MapFrom(src => src.BlockedUser ?? null))
                .ReverseMap();
            CreateMap<BlockUser, ResultBlockUserAdminDto>().ReverseMap();
            CreateMap<BlockUser, CreateBlockUserAdminDto>().ReverseMap();
            CreateMap<BlockUser, UpdateBlockUserAdminDto>().ReverseMap();

            // Comment Mappings
            CreateMap<Comment, ResultCommentWithRelationsAdminDto>()
            .ForMember(dest => dest.User, (IMemberConfigurationExpression<Comment, ResultCommentWithRelationsAdminDto, object> opt) => opt.MapFrom(src => src.User))
            .ForMember(dest => dest.CommentLikes, opt => opt.MapFrom(src => src.CommentLikes))
                        .ForMember(dest => dest.ParentComment, opt => opt.MapFrom(src => src.ParentComment))
            .ReverseMap();
            CreateMap<Comment, ResultCommentAdminDto>().ReverseMap();
            CreateMap<Comment, CreateCommentAdminDto>().ReverseMap();
            CreateMap<Comment, UpdateCommentAdminDto>().ReverseMap();

            // Follow Mappings
            CreateMap<Follow, ResultFollowWithRelationsAdminDto>()
                .ForMember(dest => dest.Follower, opt => opt.MapFrom(src => src.Follower))
                .ForMember(dest => dest.Following, opt => opt.MapFrom(src => src.Following))
                .ReverseMap();
            CreateMap<Follow, ResultFollowAdminDto>().ReverseMap();
            CreateMap<Follow, CreateFollowAdminDto>().ReverseMap();
            CreateMap<Follow, UpdateFollowAdminDto>().ReverseMap();

            // Highlight Mappings
            CreateMap<Highlight, ResultHighlightWithRelationsAdminDto>()
                .ForMember(dest => dest.Stories, opt => opt.MapFrom(src => src.StoryHighlights.Select(sh => sh.Story)))
                .ReverseMap();
            CreateMap<Highlight, ResultHighlightAdminDto>().ReverseMap();
            CreateMap<Highlight, CreateHighlightAdminDto>().ReverseMap();
            CreateMap<Highlight, UpdateHighlightAdminDto>().ReverseMap();

            // PostLike Mappings
            CreateMap<PostLike, ResultPostLikeWithRelationsAdminDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Post, opt => opt.MapFrom(src => src.Post))
                .ReverseMap();
            CreateMap<PostLike, ResultPostLikeAdminDto>().ReverseMap();
            CreateMap<PostLike, CreatePostLikeAdminDto>().ReverseMap();
            CreateMap<PostLike, UpdatePostLikeAdminDto>().ReverseMap();

            // StoryLike Mappings
            CreateMap<StoryLike, ResultStoryLikeWithRelationsAdminDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Story, opt => opt.MapFrom(src => src.Story))
                .ReverseMap();
            CreateMap<StoryLike, ResultStoryLikeAdminDto>().ReverseMap();
            CreateMap<StoryLike, CreateStoryLikeAdminDto>().ReverseMap();
            CreateMap<StoryLike, UpdateStoryLikeAdminDto>().ReverseMap();

            // Media Mappings
            CreateMap<Media, ResultMediaWithRelationsAdminDto>()
                .ReverseMap();
            CreateMap<Media, ResultMediaAdminDto>().ReverseMap();
            CreateMap<Media, CreateMediaAdminDto>().ReverseMap();
            CreateMap<Media, UpdateMediaAdminDto>().ReverseMap();

            // Message Mappings
            CreateMap<Message, ResultMessageWithRelationsAdminDto>()
                .ForMember(dest => dest.Sender, opt => opt.MapFrom(src => src.Sender))
                .ForMember(dest => dest.Receiver, opt => opt.MapFrom(src => src.Receiver))
                .ReverseMap();
            CreateMap<Message, ResultMessageAdminDto>().ReverseMap();
            CreateMap<Message, CreateMessageAdminDto>().ReverseMap();
            CreateMap<Message, UpdateMessageAdminDto>().ReverseMap();

            // Note Mappings
            CreateMap<Note, ResultNoteWithRelationsAdminDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ReverseMap();
            CreateMap<Note, ResultNoteAdminDto>().ReverseMap();
            CreateMap<Note, CreateNoteAdminDto>().ReverseMap();
            CreateMap<Note, UpdateNoteAdminDto>().ReverseMap();

            // Notification Mappings
            CreateMap<Notification, ResultNotificationWithRelationsAdminDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ReverseMap();

            CreateMap<Notification, ResultNotificationAdminDto>().ReverseMap();
            CreateMap<Notification, CreateNotificationAdminDto>().ReverseMap();
            CreateMap<Notification, UpdateNotificationAdminDto>().ReverseMap();

            // Post Mappings
            CreateMap<Post, ResultPostWithRelationsAdminDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Likes, opt => opt.MapFrom(src => src.Likes))
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments))
                .ForMember(dest => dest.SavedPosts, opt => opt.MapFrom(src => src.SavedPosts))
                .ForMember(dest => dest.TaggedUsers, opt => opt.MapFrom(src => src.TaggedUsers))
                .ReverseMap();
            CreateMap<Post, ResultPostAdminDto>().ReverseMap();
            CreateMap<Post, CreatePostAdminDto>().ReverseMap();
            CreateMap<Post, UpdatePostAdminDto>().ReverseMap();

            // Reaction Mappings
            CreateMap<Reaction, ResultReactionWithRelationsAdminDto>()
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message))
                .ReverseMap();
            CreateMap<Reaction, ResultReactionAdminDto>().ReverseMap();
            CreateMap<Reaction, CreateReactionAdminDto>().ReverseMap();
            CreateMap<Reaction, UpdateReactionAdminDto>().ReverseMap();

            // RecentChats Mappings
            CreateMap<RecentChats, ResultRecentChatsWithRelationsAdminDto>()
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users))
                .ReverseMap();
            CreateMap<RecentChats, ResultRecentChatsAdminDto>().ReverseMap();
            CreateMap<RecentChats, CreateRecentChatsAdminDto>().ReverseMap();
            CreateMap<RecentChats, UpdateRecentChatsAdminDto>().ReverseMap();

            // ReportComment Mappings
            CreateMap<ReportComment, ResultReportCommentWithRelationsAdminDto>()
                .ForMember(dest => dest.ReporterUser, opt => opt.MapFrom(src => src.ReporterUser))
                .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment))
                .ReverseMap();
            CreateMap<ReportComment, ResultReportCommentAdminDto>().ReverseMap();
            CreateMap<ReportComment, CreateReportCommentAdminDto>().ReverseMap();
            CreateMap<ReportComment, UpdateReportCommentAdminDto>().ReverseMap();

            // ReportStory Mappings
            CreateMap<ReportStory, ResultReportStoryWithRelationsAdminDto>()
                .ForMember(dest => dest.ReporterUser, opt => opt.MapFrom(src => src.ReporterUser))
                .ForMember(dest => dest.Story, opt => opt.MapFrom(src => src.Story))
                .ReverseMap();
            CreateMap<ReportStory, ResultReportStoryAdminDto>().ReverseMap();
            CreateMap<ReportStory, CreateReportStoryAdminDto>().ReverseMap();
            CreateMap<ReportStory, UpdateReportStoryAdminDto>().ReverseMap();

            // Role Mappings
            CreateMap<AppRole, ResultAppRoleWithRelationsAdminDto>().ReverseMap();
            CreateMap<AppRole, ResultAppRoleAdminDto>().ReverseMap();
            CreateMap<AppRole, CreateAppRoleAdminDto>().ReverseMap();
            CreateMap<AppRole, UpdateAppRoleAdminDto>().ReverseMap();

            // SavedPost Mappings
            CreateMap<SavedPost, ResultSavedPostWithRelationsAdminDto>().ReverseMap();
            CreateMap<SavedPost, ResultSavedPostAdminDto>().ReverseMap();
            CreateMap<SavedPost, CreateSavedPostAdminDto>().ReverseMap();
            CreateMap<SavedPost, UpdateSavedPostAdminDto>().ReverseMap();

            // SearchHistory Mappings
            CreateMap<SearchHistory, ResultSearchHistoryWithRelationsAdminDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.SearchedUsers, opt => opt.MapFrom(src => src.SearchedUsers))
                .ReverseMap();
            CreateMap<SearchHistory, ResultSearchHistoryAdminDto>().ReverseMap();
            CreateMap<SearchHistory, CreateSearchHistoryAdminDto>().ReverseMap();
            CreateMap<SearchHistory, UpdateSearchHistoryAdminDto>().ReverseMap();

            // Story Mappings
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

            // User Mappings
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

            CreateMap<AppUser, ResultAppUserAdminDto>();
            CreateMap<AppUser, RegisterDto>().ReverseMap();
            CreateMap<AppUser, UpdateAppUserAdminDto>().ReverseMap();

            // UserSetting Mappings
            CreateMap<UserSetting, ResultUserSettingWithRelationsAdminDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ReverseMap();
            CreateMap<UserSetting, ResultUserSettingAdminDto>().ReverseMap();
            CreateMap<UserSetting, CreateUserSettingAdminDto>().ReverseMap();
            CreateMap<UserSetting, UpdateUserSettingAdminDto>().ReverseMap();

            // ViewStory Mappings
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