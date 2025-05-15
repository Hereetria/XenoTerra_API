
using AutoMapper;
using XenoTerra.EntityLayer.Entities;
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
using XenoTerra.DTOLayer.Dtos.RoleDtos;
using XenoTerra.DTOLayer.Dtos.SavedPostDtos;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;
using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.DTOLayer.Dtos.UserSettingDtos;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos.HighlightDtos;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;

namespace XenoTerra.DTOLayer.Mappings
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            // BlockUser Mappings
            CreateMap<BlockUser, ResultBlockUserWithRelationsDto>()
                .ForMember(dest => dest.BlockingUser, opt => opt.MapFrom(src => src.BlockingUser ?? null))
                .ForMember(dest => dest.BlockedUser, opt => opt.MapFrom(src => src.BlockedUser ?? null))

                .ReverseMap();
            CreateMap<BlockUser, ResultBlockUserDto>().ReverseMap();
            CreateMap<BlockUser, CreateCommentckUserDto>().ReverseMap();
            CreateMap<BlockUser, UpdateBlockUserDto>().ReverseMap();

            // Comment Mappings
        CreateMap<Comment, ResultCommentWithRelationsDto>()
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
            .ForMember(dest => dest.Post, opt => opt.MapFrom(src => src.Post))
            .ReverseMap();
            CreateMap<Comment, ResultCommentDto>().ReverseMap();
            CreateMap<Comment, CreateCommentDto>().ReverseMap();
            CreateMap<Comment, UpdateCommentDto>().ReverseMap();

            // Follow Mappings
            CreateMap<Follow, ResultFollowWithRelationsDto>()
                .ForMember(dest => dest.Follower, opt => opt.MapFrom(src => src.Follower))
                .ForMember(dest => dest.Following, opt => opt.MapFrom(src => src.Following))
                .ReverseMap();
            CreateMap<Follow, ResultFollowDto>().ReverseMap();
            CreateMap<Follow, CreateFollowDto>().ReverseMap();
            CreateMap<Follow, UpdateFollowDto>().ReverseMap();

            // Highlight Mappings
            CreateMap<Highlight, ResultHighlightWithRelationsDto>()
                .ForMember(dest => dest.Stories, opt => opt.MapFrom(src => src.StoryHighlights.Select(sh => sh.Story)))
                .ReverseMap();
            CreateMap<Highlight, ResultHighlightDto>().ReverseMap();
            CreateMap<Highlight, CreateHighlightDto>().ReverseMap();
            CreateMap<Highlight, UpdateHighlightDto>().ReverseMap();

            // Like Mappings
            CreateMap<Like, ResultLikeWithRelationsDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Post, opt => opt.MapFrom(src => src.Post))
                .ReverseMap();
            CreateMap<Like, ResultLikeDto>().ReverseMap();
            CreateMap<Like, CreateLikeDto>().ReverseMap();
            CreateMap<Like, UpdateLikeDto>().ReverseMap();

            // Media Mappings
            CreateMap<Media, ResultMediaWithRelationsDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ReverseMap();
            CreateMap<Media, ResultMediaDto>().ReverseMap();
            CreateMap<Media, CreateMediaDto>().ReverseMap();
            CreateMap<Media, UpdateMediaDto>().ReverseMap();

            // Message Mappings
            CreateMap<Message, ResultMessageWithRelationsDto>()
                .ForMember(dest => dest.Sender, opt => opt.MapFrom(src => src.Sender))
                .ForMember(dest => dest.Receiver, opt => opt.MapFrom(src => src.Receiver))
                .ReverseMap();
            CreateMap<Message, ResultMessageDto>().ReverseMap();
            CreateMap<Message, CreateMessageDto>().ReverseMap();
            CreateMap<Message, UpdateMessageDto>().ReverseMap();

            // Note Mappings
            CreateMap<Note, ResultNoteWithRelationsDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ReverseMap();
            CreateMap<Note, ResultNoteDto>().ReverseMap();
            CreateMap<Note, CreateNoteDto>().ReverseMap();
            CreateMap<Note, UpdateNoteDto>().ReverseMap();

            // Notification Mappings
            CreateMap<Notification, ResultNotificationWithRelationsDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ReverseMap();

            CreateMap<Notification, ResultNotificationDto>().ReverseMap();
            CreateMap<Notification, CreateNotificationDto>().ReverseMap();
            CreateMap<Notification, UpdateNotificationDto>().ReverseMap();

            // Post Mappings
            CreateMap<Post, ResultPostWithRelationsDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Likes, opt => opt.MapFrom(src => src.Likes))
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments))
                .ForMember(dest => dest.SavedPosts, opt => opt.MapFrom(src => src.SavedPosts))
                .ForMember(dest => dest.TaggedUsers, opt => opt.MapFrom(src => src.TaggedUsers))
                .ReverseMap();
            CreateMap<Post, ResultPostDto>().ReverseMap();
            CreateMap<Post, CreatePostDto>().ReverseMap();
            CreateMap<Post, UpdatePostDto>().ReverseMap();

            // Reaction Mappings
            CreateMap<Reaction, ResultReactionWithRelationsDto>()
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ReverseMap();
            CreateMap<Reaction, ResultReactionDto>().ReverseMap();
            CreateMap<Reaction, CreateReactionDto>().ReverseMap();
            CreateMap<Reaction, UpdateReactionDto>().ReverseMap();

            // RecentChats Mappings
            CreateMap<RecentChats, ResultRecentChatsWithRelationsDto>()
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users))
                .ReverseMap();
            CreateMap<RecentChats, ResultRecentChatsDto>().ReverseMap();
            CreateMap<RecentChats, CreateRecentChatsDto>().ReverseMap();
            CreateMap<RecentChats, UpdateRecentChatsDto>().ReverseMap();

            // ReportComment Mappings
            CreateMap<ReportComment, ResultReportCommentWithRelationsDto>()
                .ForMember(dest => dest.ReporterUser, opt => opt.MapFrom(src => src.ReporterUser))
                .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment))
                .ReverseMap();
            CreateMap<ReportComment, ResultReportCommentDto>().ReverseMap();
            CreateMap<ReportComment, CreateReportCommentDto>().ReverseMap();
            CreateMap<ReportComment, UpdateReportCommentDto>().ReverseMap();

            // Role Mappings
            CreateMap<Role, ResultRoleWithRelationsDto>().ReverseMap();
            CreateMap<Role, ResultRoleDto>().ReverseMap();
            CreateMap<Role, CreateRoleDto>().ReverseMap();
            CreateMap<Role, UpdateRoleDto>().ReverseMap();

            // SavedPost Mappings
            CreateMap<SavedPost, ResultSavedPostWithRelationsDto>().ReverseMap();
            CreateMap<SavedPost, ResultSavedPostDto>().ReverseMap();
            CreateMap<SavedPost, CreateSavedPostDto>().ReverseMap();
            CreateMap<SavedPost, UpdateSavedPostDto>().ReverseMap();

            // SearchHistory Mappings
            CreateMap<SearchHistory, ResultSearchHistoryWithRelationsDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.SearchedUsers, opt => opt.MapFrom(src => src.SearchedUsers))
                .ReverseMap();
            CreateMap<SearchHistory, ResultSearchHistoryDto>().ReverseMap();
            CreateMap<SearchHistory, CreateSearchHistoryDto>().ReverseMap();
            CreateMap<SearchHistory, UpdateSearchHistoryDto>().ReverseMap();

            // Story Mappings
            CreateMap<Story, ResultStoryWithRelationsDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.ViewStories, opt => opt.MapFrom(src => src.ViewStories))
                .ForMember(dest => dest.Highlights, opt => opt.MapFrom(src => src.StoryHighlights.Select(sh => sh.Highlight)))
                .ReverseMap();
            CreateMap<Story, ResultStoryDto>().ReverseMap();
            CreateMap<Story, CreateStoryDto>().ReverseMap();
            CreateMap<Story, UpdateStoryDto>().ReverseMap();

            // User Mappings
            CreateMap<User, ResultUserWithRelationsDto>()
                .ForMember(dest => dest.Posts, opt => opt.MapFrom(src => src.Posts))
                .ForMember(dest => dest.Followers, opt => opt.MapFrom(src => src.Followers))
                .ForMember(dest => dest.Followings, opt => opt.MapFrom(src => src.Followings))
                .ForMember(dest => dest.Likes, opt => opt.MapFrom(src => src.Likes))
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments))
                .ForMember(dest => dest.SentMessages, opt => opt.MapFrom(src => src.SentMessages))
                .ForMember(dest => dest.ReceivedMessages, opt => opt.MapFrom(src => src.ReceivedMessages))
                .ForMember(dest => dest.Notifications, opt => opt.MapFrom(src => src.Notifications))
                .ForMember(dest => dest.Medias, opt => opt.MapFrom(src => src.Medias))
                .ForMember(dest => dest.Stories, opt => opt.MapFrom(src => src.Stories))
                .ForMember(dest => dest.SavedPosts, opt => opt.MapFrom(src => src.SavedPosts))
                .ForMember(dest => dest.ReportComments, opt => opt.MapFrom(src => src.ReportComments))
                .ForMember(dest => dest.ViewStories, opt => opt.MapFrom(src => src.ViewStories))
                .ForMember(dest => dest.UserSettings, opt => opt.MapFrom(src => src.UserSettings))
                .ForMember(dest => dest.SearchedBy, opt => opt.MapFrom(src => src.SearchedBy))
                .ForMember(dest => dest.RecentChats, opt => opt.MapFrom(src => src.RecentChats))
                .ForMember(dest => dest.Note, opt => opt.MapFrom(src => src.Note))
                .ForMember(dest => dest.Reactions, opt => opt.MapFrom(src => src.Reactions))
                .ForMember(dest => dest.TaggedPosts, opt => opt.MapFrom(src => src.TaggedPosts))
                .ReverseMap();
            CreateMap<User, ResultUserDto>().ReverseMap();
            CreateMap<User, RegisterDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();

            // UserSetting Mappings
            CreateMap<UserSetting, ResultUserSettingWithRelationsDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ReverseMap();
            CreateMap<UserSetting, ResultUserSettingDto>().ReverseMap();
            CreateMap<UserSetting, CreateUserSettingDto>().ReverseMap();
            CreateMap<UserSetting, UpdateUserSettingDto>().ReverseMap();

            // ViewStory Mappings
            CreateMap<ViewStory, ResultViewStoryWithRelationsDto>()
                .ForMember(dest => dest.Story, opt => opt.MapFrom(src => src.Story))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ReverseMap();
            CreateMap<ViewStory, ResultViewStoryDto>().ReverseMap();
            CreateMap<ViewStory, CreateViewStoryDto>().ReverseMap();
            CreateMap<ViewStory, UpdateViewStoryDto>().ReverseMap();
        }
    }
}