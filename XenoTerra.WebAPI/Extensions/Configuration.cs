using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using XenoTerra.DataAccessLayer.Contexts;
using Microsoft.EntityFrameworkCore;
using XenoTerra.DTOLayer.Mappings;
using System.Reflection;
using XenoTerra.WebAPI.Schemas.Mutations;
using XenoTerra.WebAPI.Schemas.Queries;
using XenoTerra.WebAPI.Schemas.Types;
using XenoTerra.WebAPI.Schemas.DataLoaders;
using XenoTerra.WebAPI.Schemas.Resolvers;
using Microsoft.EntityFrameworkCore.Migrations;
using XenoTerra.BussinessLogicLayer.Services.Entity.BlockUserService;
using XenoTerra.DataAccessLayer.Repositories.Entity.BlockUserRepository;
using XenoTerra.BussinessLogicLayer.Services.Entity.CommentService;
using XenoTerra.BussinessLogicLayer.Services.Entity.FollowService;
using XenoTerra.BussinessLogicLayer.Services.Entity.HighlightService;
using XenoTerra.BussinessLogicLayer.Services.Entity.LikeService;
using XenoTerra.BussinessLogicLayer.Services.Entity.MediaService;
using XenoTerra.BussinessLogicLayer.Services.Entity.MessageService;
using XenoTerra.BussinessLogicLayer.Services.Entity.NoteService;
using XenoTerra.BussinessLogicLayer.Services.Entity.NotificationService;
using XenoTerra.BussinessLogicLayer.Services.Entity.PostService;
using XenoTerra.BussinessLogicLayer.Services.Entity.PostTagService;
using XenoTerra.BussinessLogicLayer.Services.Entity.ReactionService;
using XenoTerra.BussinessLogicLayer.Services.Entity.RecentChatsService;
using XenoTerra.BussinessLogicLayer.Services.Entity.ReportCommentService;
using XenoTerra.BussinessLogicLayer.Services.Entity.RoleService;
using XenoTerra.BussinessLogicLayer.Services.Entity.SavedPostService;
using XenoTerra.BussinessLogicLayer.Services.Entity.SearchHistoryService;
using XenoTerra.BussinessLogicLayer.Services.Entity.StoryService;
using XenoTerra.BussinessLogicLayer.Services.Entity.UserService;
using XenoTerra.BussinessLogicLayer.Services.Entity.UserSettingService;
using XenoTerra.BussinessLogicLayer.Services.Entity.ViewStoryService;
using XenoTerra.DataAccessLayer.Repositories.Entity.CommentRepository;
using XenoTerra.DataAccessLayer.Repositories.Entity.FollowRepository;
using XenoTerra.DataAccessLayer.Repositories.Entity.HighlightRepository;
using XenoTerra.DataAccessLayer.Repositories.Entity.HighlightStoryRepository;
using XenoTerra.DataAccessLayer.Repositories.Entity.LikeRepository;
using XenoTerra.DataAccessLayer.Repositories.Entity.MediaRepository;
using XenoTerra.DataAccessLayer.Repositories.Entity.MessageRepository;
using XenoTerra.DataAccessLayer.Repositories.Entity.NoteRepository;
using XenoTerra.DataAccessLayer.Repositories.Entity.NotificationRepository;
using XenoTerra.DataAccessLayer.Repositories.Entity.PostRepository;
using XenoTerra.DataAccessLayer.Repositories.Entity.PostTagRepository;
using XenoTerra.DataAccessLayer.Repositories.Entity.ReactionRepository;
using XenoTerra.DataAccessLayer.Repositories.Entity.RecentChatsRepository;
using XenoTerra.DataAccessLayer.Repositories.Entity.ReportCommentRepository;
using XenoTerra.DataAccessLayer.Repositories.Entity.RoleRepository;
using XenoTerra.DataAccessLayer.Repositories.Entity.SavedPostRepository;
using XenoTerra.DataAccessLayer.Repositories.Entity.SearchHistoryRepository;
using XenoTerra.DataAccessLayer.Repositories.Entity.StoryHighlightRepository;
using XenoTerra.DataAccessLayer.Repositories.Entity.StoryRepository;
using XenoTerra.DataAccessLayer.Repositories.Entity.UserRepository;
using XenoTerra.DataAccessLayer.Repositories.Entity.UserSettingRepository;
using XenoTerra.DataAccessLayer.Repositories.Entity.ViewStoryRepository;
using XenoTerra.BussinessLogicLayer.Services.Entity.StoryHighlightService;
using XenoTerra.BussinessLogicLayer.Services.Entity.SearchHistoryUserService;
using XenoTerra.DataAccessLayer.Repositories.Entity.SearchHistoryUserRepository;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.DataAccessLayer.Repositories.Generic.Write;

namespace XenoTerra.WebAPI.Extensions
{
        public class Configuration
    {

        public static void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddType<ResultBlockUserDtoType>()
                .AddType<ResultHighlightDtoType>()
                .AddProjections()
                .AddFiltering()
                .AddDataLoader<UserDataLoader>()
                .AddDataLoader<StoryDataLoader>()
                .AddDataLoader<HighlightStoryDataLoader>();

            builder.Services.AddScoped<BlockUserResolver>();
            builder.Services.AddScoped<HighlightResolver>();


            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            builder.Services.AddAutoMapper(typeof(GeneralMapping));


            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Scoped);

            builder.Services.AddScoped(typeof(IReadRepository<,>), typeof(ReadRepository<,>));
            builder.Services.AddScoped(typeof(IWriteRepository<,>), typeof(WriteRepository<,>));



            builder.Services.AddScoped<IBlockUserReadService, BlockUserReadService>();
            builder.Services.AddScoped<IBlockUserWriteService, BlockUserWriteService>();
            builder.Services.AddScoped<IBlockUserReadRepository, BlockUserReadRepository>();
            builder.Services.AddScoped<IBlockUserWriteRepository, BlockUserWriteRepository>();

            builder.Services.AddScoped<ICommentReadService, CommentReadService>();
            builder.Services.AddScoped<ICommentWriteService, CommentWriteService>();
            builder.Services.AddScoped<ICommentReadRepository, CommentReadRepository>();
            builder.Services.AddScoped<ICommentWriteRepository, CommentWriteRepository>();

            builder.Services.AddScoped<IFollowReadService, FollowReadService>();
            builder.Services.AddScoped<IFollowWriteService, FollowWriteService>();
            builder.Services.AddScoped<IFollowReadRepository, FollowReadRepository>();
            builder.Services.AddScoped<IFollowWriteRepository, FollowWriteRepository>();

            builder.Services.AddScoped<IHighlightReadService, HighlightReadService>();
            builder.Services.AddScoped<IHighlightWriteService, HighlightWriteService>();
            builder.Services.AddScoped<IHighlightReadRepository, HighlightReadRepository>();
            builder.Services.AddScoped<IHighlightWriteRepository, HighlightWriteRepository>();

            builder.Services.AddScoped<IStoryHighlightReadService, StoryHighlightReadService>();
            builder.Services.AddScoped<IStoryHighlightWriteService, StoryHighlightWriteService>();
            builder.Services.AddScoped<IStoryHighlightReadRepository, StoryHighlightReadRepository>();
            builder.Services.AddScoped<IStoryHighlightWriteRepository, StoryHighlightWriteRepository>();

            builder.Services.AddScoped<ILikeReadService, LikeReadService>();
            builder.Services.AddScoped<ILikeWriteService, LikeWriteService>();
            builder.Services.AddScoped<ILikeReadRepository, LikeReadRepository>();
            builder.Services.AddScoped<ILikeWriteRepository, LikeWriteRepository>();

            builder.Services.AddScoped<IMediaReadService, MediaReadService>();
            builder.Services.AddScoped<IMediaWriteService, MediaWriteService>();
            builder.Services.AddScoped<IMediaReadRepository, MediaReadRepository>();
            builder.Services.AddScoped<IMediaWriteRepository, MediaWriteRepository>();

            builder.Services.AddScoped<IMessageReadService, MessageReadService>();
            builder.Services.AddScoped<IMessageWriteService, MessageWriteService>();
            builder.Services.AddScoped<IMessageReadRepository, MessageReadRepository>();
            builder.Services.AddScoped<IMessageWriteRepository, MessageWriteRepository>();

            builder.Services.AddScoped<INoteReadService, NoteReadService>();
            builder.Services.AddScoped<INoteWriteService, NoteWriteService>();
            builder.Services.AddScoped<INoteReadRepository, NoteReadRepository>();
            builder.Services.AddScoped<INoteWriteRepository, NoteWriteRepository>();

            builder.Services.AddScoped<INotificationReadService, NotificationReadService>();
            builder.Services.AddScoped<INotificationWriteService, NotificationWriteService>();
            builder.Services.AddScoped<INotificationReadRepository, NotificationReadRepository>();
            builder.Services.AddScoped<INotificationWriteRepository, NotificationWriteRepository>();

            builder.Services.AddScoped<IPostReadService, PostReadService>();
            builder.Services.AddScoped<IPostWriteService, PostWriteService>();
            builder.Services.AddScoped<IPostReadRepository, PostReadRepository>();
            builder.Services.AddScoped<IPostWriteRepository, PostWriteRepository>();

            builder.Services.AddScoped<IPostTagReadService, PostTagReadService>();
            builder.Services.AddScoped<IPostTagWriteService, PostTagWriteService>();
            builder.Services.AddScoped<IPostTagReadRepository, PostTagReadRepository>();
            builder.Services.AddScoped<IPostTagWriteRepository, PostTagWriteRepository>();

            builder.Services.AddScoped<IReactionReadService, ReactionReadService>();
            builder.Services.AddScoped<IReactionWriteService, ReactionWriteService>();
            builder.Services.AddScoped<IReactionReadRepository, ReactionReadRepository>();
            builder.Services.AddScoped<IReactionWriteRepository, ReactionWriteRepository>();

            builder.Services.AddScoped<IRecentChatsReadService, RecentChatsReadService>();
            builder.Services.AddScoped<IRecentChatsWriteService, RecentChatsWriteService>();
            builder.Services.AddScoped<IRecentChatsReadRepository, RecentChatsReadRepository>();
            builder.Services.AddScoped<IRecentChatsWriteRepository, RecentChatsWriteRepository>();

            builder.Services.AddScoped<IReportCommentReadService, ReportCommentReadService>();
            builder.Services.AddScoped<IReportCommentWriteService, ReportCommentWriteService>();
            builder.Services.AddScoped<IReportCommentReadRepository, ReportCommentReadRepository>();
            builder.Services.AddScoped<IReportCommentWriteRepository, ReportCommentWriteRepository>();

            builder.Services.AddScoped<IRoleReadService, RoleReadService>();
            builder.Services.AddScoped<IRoleWriteService, RoleWriteService>();
            builder.Services.AddScoped<IRoleReadRepository, RoleReadRepository>();
            builder.Services.AddScoped<IRoleWriteRepository, RoleWriteRepository>();

            builder.Services.AddScoped<ISavedPostReadService, SavedPostReadService>();
            builder.Services.AddScoped<ISavedPostWriteService, SavedPostWriteService>();
            builder.Services.AddScoped<ISavedPostReadRepository, SavedPostReadRepository>();
            builder.Services.AddScoped<ISavedPostWriteRepository, SavedPostWriteRepository>();

            builder.Services.AddScoped<ISearchHistoryReadService, SearchHistoryReadService>();
            builder.Services.AddScoped<ISearchHistoryWriteService, SearchHistoryWriteService>();
            builder.Services.AddScoped<ISearchHistoryReadRepository, SearchHistoryReadRepository>();
            builder.Services.AddScoped<ISearchHistoryWriteRepository, SearchHistoryWriteRepository>();

            builder.Services.AddScoped<ISearchHistoryUserReadService, SearchHistoryUserReadService>();
            builder.Services.AddScoped<ISearchHistoryUserWriteService, SearchHistoryUserWriteService>();
            builder.Services.AddScoped<ISearchHistoryUserReadRepository, SearchHistoryUserReadRepository>();
            builder.Services.AddScoped<ISearchHistoryUserWriteRepository, SearchHistoryUserWriteRepository>();

            builder.Services.AddScoped<IStoryReadService, StoryReadService>();
            builder.Services.AddScoped<IStoryWriteService, StoryWriteService>();
            builder.Services.AddScoped<IStoryReadRepository, StoryReadRepository>();
            builder.Services.AddScoped<IStoryWriteRepository, StoryWriteRepository>();

            builder.Services.AddScoped<IUserReadService, UserReadService>();
            builder.Services.AddScoped<IUserWriteService, UserWriteService>();
            builder.Services.AddScoped<IUserReadRepository, UserReadRepository>();
            builder.Services.AddScoped<IUserWriteRepository, UserWriteRepository>();

            builder.Services.AddScoped<IUserSettingReadService, UserSettingReadService>();
            builder.Services.AddScoped<IUserSettingWriteService, UserSettingWriteService>();
            builder.Services.AddScoped<IUserSettingReadRepository, UserSettingReadRepository>();
            builder.Services.AddScoped<IUserSettingWriteRepository, UserSettingWriteRepository>();

            builder.Services.AddScoped<IViewStoryReadService, ViewStoryReadService>();
            builder.Services.AddScoped<IViewStoryWriteService, ViewStoryWriteService>();
            builder.Services.AddScoped<IViewStoryReadRepository, ViewStoryReadRepository>();
            builder.Services.AddScoped<IViewStoryWriteRepository, ViewStoryWriteRepository>();


        }
    }
}