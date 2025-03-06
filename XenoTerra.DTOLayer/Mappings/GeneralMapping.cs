
using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.DTOLayer.Dtos.CommentDtos;
using XenoTerra.DTOLayer.Dtos.FollowDtos;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.DTOLayer.Dtos.LikeDtos;
using XenoTerra.DTOLayer.Dtos.MediaDtos;
using XenoTerra.DTOLayer.Dtos.MessageDtos;
using XenoTerra.DTOLayer.Dtos.NoteDtos;
using XenoTerra.DTOLayer.Dtos.NotificationDtos;
using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.DTOLayer.Dtos.PostTagDtos;
using XenoTerra.DTOLayer.Dtos.ReactionDtos;
using XenoTerra.DTOLayer.Dtos.RecentChatsDtos;
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;
using XenoTerra.DTOLayer.Dtos.RoleDtos;
using XenoTerra.DTOLayer.Dtos.SavedPostDtos;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;
using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos;
using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.DTOLayer.Dtos.UserSettingDtos;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;

namespace XenoTerra.DTOLayer.Mappings
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            // BlockUser Mappings
            CreateMap<BlockUser, ResultBlockUserWithRelationsDto>().ReverseMap();
            CreateMap<BlockUser, ResultBlockUserDto>().ReverseMap();
            CreateMap<BlockUser, CreateBlockUserDto>().ReverseMap();
            CreateMap<BlockUser, UpdateBlockUserDto>().ReverseMap();

            // Comment Mappings
            CreateMap<Comment, ResultCommentWithRelationsDto>().ReverseMap();
            CreateMap<Comment, ResultCommentDto>().ReverseMap();
            CreateMap<Comment, CreateCommentDto>().ReverseMap();
            CreateMap<Comment, UpdateCommentDto>().ReverseMap();

            // Follow Mappings
            CreateMap<Follow, ResultFollowWithRelationsDto>().ReverseMap();
            CreateMap<Follow, ResultFollowDto>().ReverseMap();
            CreateMap<Follow, CreateFollowDto>().ReverseMap();
            CreateMap<Follow, UpdateFollowDto>().ReverseMap();

            // Highlight Mappings
            CreateMap<Highlight, ResultHighlightWithRelationsDto>().ReverseMap();
            CreateMap<Highlight, ResultHighlightDto>().ReverseMap();
            CreateMap<Highlight, CreateHighlightDto>().ReverseMap();
            CreateMap<Highlight, UpdateHighlightDto>().ReverseMap();

            // Like Mappings
            CreateMap<Like, ResultLikeWithRelationsDto>().ReverseMap();
            CreateMap<Like, ResultLikeDto>().ReverseMap();
            CreateMap<Like, CreateLikeDto>().ReverseMap();
            CreateMap<Like, UpdateLikeDto>().ReverseMap();

            // Media Mappings
            CreateMap<Media, ResultMediaWithRelationsDto>().ReverseMap();
            CreateMap<Media, ResultMediaDto>().ReverseMap();
            CreateMap<Media, CreateMediaDto>().ReverseMap();
            CreateMap<Media, UpdateMediaDto>().ReverseMap();

            // Message Mappings
            CreateMap<Message, ResultMessageWithRelationsDto>().ReverseMap();
            CreateMap<Message, ResultMessageDto>().ReverseMap();
            CreateMap<Message, CreateMessageDto>().ReverseMap();
            CreateMap<Message, UpdateMessageDto>().ReverseMap();

            // Note Mappings
            CreateMap<Note, ResultNoteWithRelationsDto>().ReverseMap();
            CreateMap<Note, ResultNoteDto>().ReverseMap();
            CreateMap<Note, CreateNoteDto>().ReverseMap();
            CreateMap<Note, UpdateNoteDto>().ReverseMap();

            // Notification Mappings
            CreateMap<Notification, ResultNotificationWithRelationsDto>().ReverseMap();
            CreateMap<Notification, ResultNotificationDto>().ReverseMap();
            CreateMap<Notification, CreateNotificationDto>().ReverseMap();
            CreateMap<Notification, UpdateNotificationDto>().ReverseMap();

            // Post Mappings
            CreateMap<Post, ResultPostWithRelationsDto>().ReverseMap();
            CreateMap<Post, ResultPostDto>().ReverseMap();
            CreateMap<Post, CreatePostDto>().ReverseMap();
            CreateMap<Post, UpdatePostDto>().ReverseMap();

            // PostTag Mappings
            CreateMap<PostTag, ResultPostTagWithRelationsDto>().ReverseMap();
            CreateMap<PostTag, ResultPostTagDto>().ReverseMap();
            CreateMap<PostTag, CreatePostTagDto>().ReverseMap();
            CreateMap<PostTag, UpdatePostTagDto>().ReverseMap();

            // Reaction Mappings
            CreateMap<Reaction, ResultReactionWithRelationsDto>().ReverseMap();
            CreateMap<Reaction, ResultReactionDto>().ReverseMap();
            CreateMap<Reaction, CreateReactionDto>().ReverseMap();
            CreateMap<Reaction, UpdateReactionDto>().ReverseMap();

            // RecentChats Mappings
            CreateMap<RecentChats, ResultRecentChatsWithRelationsDto>().ReverseMap();
            CreateMap<RecentChats, ResultRecentChatsDto>().ReverseMap();
            CreateMap<RecentChats, CreateRecentChatsDto>().ReverseMap();
            CreateMap<RecentChats, UpdateRecentChatsDto>().ReverseMap();

            // ReportComment Mappings
            CreateMap<ReportComment, ResultReportCommentWithRelationsDto>().ReverseMap();
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
            CreateMap<SearchHistory, ResultSearchHistoryWithRelationsDto>().ReverseMap();
            CreateMap<SearchHistory, ResultSearchHistoryDto>().ReverseMap();
            CreateMap<SearchHistory, CreateSearchHistoryDto>().ReverseMap();
            CreateMap<SearchHistory, UpdateSearchHistoryDto>().ReverseMap();

            // SearchHistoryUser Mappings
            CreateMap<SearchHistoryUser, ResultSearchHistoryUserWithRelationsDto>().ReverseMap();
            CreateMap<SearchHistoryUser, ResultSearchHistoryUserDto>().ReverseMap();
            CreateMap<SearchHistoryUser, CreateSearchHistoryUserDto>().ReverseMap();
            CreateMap<SearchHistoryUser, UpdateSearchHistoryUserDto>().ReverseMap();

            // Story Mappings
            CreateMap<Story, ResultStoryWithRelationsDto>().ReverseMap();
            CreateMap<Story, ResultStoryDto>().ReverseMap();
            CreateMap<Story, CreateStoryDto>().ReverseMap();
            CreateMap<Story, UpdateStoryDto>().ReverseMap();

            // User Mappings
            CreateMap<User, ResultUserWithRelationsDto>().ReverseMap();
            CreateMap<User, ResultUserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();

            // UserSetting Mappings
            CreateMap<UserSetting, ResultUserSettingWithRelationsDto>().ReverseMap();
            CreateMap<UserSetting, ResultUserSettingDto>().ReverseMap();
            CreateMap<UserSetting, CreateUserSettingDto>().ReverseMap();
            CreateMap<UserSetting, UpdateUserSettingDto>().ReverseMap();

            // ViewStory Mappings
            CreateMap<ViewStory, ResultViewStoryWithRelationsDto>().ReverseMap();
            CreateMap<ViewStory, ResultViewStoryDto>().ReverseMap();
            CreateMap<ViewStory, CreateViewStoryDto>().ReverseMap();
            CreateMap<ViewStory, UpdateViewStoryDto>().ReverseMap();
        }
    }
}