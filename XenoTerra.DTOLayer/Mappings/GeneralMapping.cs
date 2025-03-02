
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
            CreateMap<BlockUser, ResultBlockUserDto>().ReverseMap();
            CreateMap<BlockUser, ResultBlockUserByIdDto>().ReverseMap();
            CreateMap<BlockUser, CreateBlockUserDto>().ReverseMap();
            CreateMap<BlockUser, UpdateBlockUserDto>().ReverseMap();

            CreateMap<Comment, ResultCommentDto>().ReverseMap();
            CreateMap<Comment, ResultCommentByIdDto>().ReverseMap();
            CreateMap<Comment, CreateCommentDto>().ReverseMap();
            CreateMap<Comment, UpdateCommentDto>().ReverseMap();

            CreateMap<Follow, ResultFollowDto>().ReverseMap();
            CreateMap<Follow, ResultFollowByIdDto>().ReverseMap();
            CreateMap<Follow, CreateFollowDto>().ReverseMap();
            CreateMap<Follow, UpdateFollowDto>().ReverseMap();

            CreateMap<Highlight, ResultHighlightDto>().ReverseMap();
            CreateMap<Highlight, ResultHighlightByIdDto>().ReverseMap();
            CreateMap<Highlight, CreateHighlightDto>().ReverseMap();
            CreateMap<Highlight, UpdateHighlightDto>().ReverseMap();

            CreateMap<Like, ResultLikeDto>().ReverseMap();
            CreateMap<Like, ResultLikeByIdDto>().ReverseMap();
            CreateMap<Like, CreateLikeDto>().ReverseMap();
            CreateMap<Like, UpdateLikeDto>().ReverseMap();

            CreateMap<Media, ResultMediaDto>().ReverseMap();
            CreateMap<Media, ResultMediaByIdDto>().ReverseMap();
            CreateMap<Media, CreateMediaDto>().ReverseMap();
            CreateMap<Media, UpdateMediaDto>().ReverseMap();

            CreateMap<Message, ResultMessageDto>().ReverseMap();
            CreateMap<Message, ResultMessageByIdDto>().ReverseMap();
            CreateMap<Message, CreateMessageDto>().ReverseMap();
            CreateMap<Message, UpdateMessageDto>().ReverseMap();

            CreateMap<Note, ResultNoteDto>().ReverseMap();
            CreateMap<Note, ResultNoteByIdDto>().ReverseMap();
            CreateMap<Note, CreateNoteDto>().ReverseMap();
            CreateMap<Note, UpdateNoteDto>().ReverseMap();

            CreateMap<Notification, ResultNotificationDto>().ReverseMap();
            CreateMap<Notification, ResultNotificationByIdDto>().ReverseMap();
            CreateMap<Notification, CreateNotificationDto>().ReverseMap();
            CreateMap<Notification, UpdateNotificationDto>().ReverseMap();

            CreateMap<Post, ResultPostDto>().ReverseMap();
            CreateMap<Post, ResultPostByIdDto>().ReverseMap();
            CreateMap<Post, CreatePostDto>().ReverseMap();
            CreateMap<Post, UpdatePostDto>().ReverseMap();

            CreateMap<PostTag, ResultPostTagDto>().ReverseMap();
            CreateMap<PostTag, ResultPostTagByIdDto>().ReverseMap();
            CreateMap<PostTag, CreatePostTagDto>().ReverseMap();
            CreateMap<PostTag, UpdatePostTagDto>().ReverseMap();

            CreateMap<Reaction, ResultReactionDto>().ReverseMap();
            CreateMap<Reaction, ResultReactionByIdDto>().ReverseMap();
            CreateMap<Reaction, CreateReactionDto>().ReverseMap();
            CreateMap<Reaction, UpdateReactionDto>().ReverseMap();

            CreateMap<RecentChats, ResultRecentChatsDto>().ReverseMap();
            CreateMap<RecentChats, ResultRecentChatsByIdDto>().ReverseMap();
            CreateMap<RecentChats, CreateRecentChatsDto>().ReverseMap();
            CreateMap<RecentChats, UpdateRecentChatsDto>().ReverseMap();

            CreateMap<ReportComment, ResultReportCommentDto>().ReverseMap();
            CreateMap<ReportComment, ResultReportCommentByIdDto>().ReverseMap();
            CreateMap<ReportComment, CreateReportCommentDto>().ReverseMap();
            CreateMap<ReportComment, UpdateReportCommentDto>().ReverseMap();

            CreateMap<Role, ResultRoleDto>().ReverseMap();
            CreateMap<Role, ResultRoleByIdDto>().ReverseMap();
            CreateMap<Role, CreateRoleDto>().ReverseMap();
            CreateMap<Role, UpdateRoleDto>().ReverseMap();

            CreateMap<SavedPost, ResultSavedPostDto>().ReverseMap();
            CreateMap<SavedPost, ResultSavedPostByIdDto>().ReverseMap();
            CreateMap<SavedPost, CreateSavedPostDto>().ReverseMap();
            CreateMap<SavedPost, UpdateSavedPostDto>().ReverseMap();

            CreateMap<SearchHistory, ResultSearchHistoryDto>().ReverseMap();
            CreateMap<SearchHistory, ResultSearchHistoryByIdDto>().ReverseMap();
            CreateMap<SearchHistory, CreateSearchHistoryDto>().ReverseMap();
            CreateMap<SearchHistory, UpdateSearchHistoryDto>().ReverseMap();

            CreateMap<SearchHistoryUser, ResultSearchHistoryUserDto>().ReverseMap();
            CreateMap<SearchHistoryUser, ResultSearchHistoryUserByIdDto>().ReverseMap();
            CreateMap<SearchHistoryUser, CreateSearchHistoryUserDto>().ReverseMap();
            CreateMap<SearchHistoryUser, UpdateSearchHistoryUserDto>().ReverseMap();

            CreateMap<Story, ResultStoryDto>().ReverseMap();
            CreateMap<Story, ResultStoryByIdDto>().ReverseMap();
            CreateMap<Story, CreateStoryDto>().ReverseMap();
            CreateMap<Story, UpdateStoryDto>().ReverseMap();

            CreateMap<User, ResultUserDto>().ReverseMap();
            CreateMap<User, ResultUserByIdDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();

            CreateMap<UserSetting, ResultUserSettingDto>().ReverseMap();
            CreateMap<UserSetting, ResultUserSettingByIdDto>().ReverseMap();
            CreateMap<UserSetting, CreateUserSettingDto>().ReverseMap();
            CreateMap<UserSetting, UpdateUserSettingDto>().ReverseMap();

            CreateMap<ViewStory, ResultViewStoryDto>().ReverseMap();
            CreateMap<ViewStory, ResultViewStoryByIdDto>().ReverseMap();
            CreateMap<ViewStory, CreateViewStoryDto>().ReverseMap();
            CreateMap<ViewStory, UpdateViewStoryDto>().ReverseMap();

        }
    }
}