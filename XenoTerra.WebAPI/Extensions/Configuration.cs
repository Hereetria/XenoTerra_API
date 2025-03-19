using XenoTerra.DataAccessLayer.Contexts;
using Microsoft.EntityFrameworkCore;
using XenoTerra.DTOLayer.Mappings;
using System.Reflection;
using XenoTerra.WebAPI.Schemas.Mutations;
using XenoTerra.WebAPI.Schemas.Queries;
using XenoTerra.WebAPI.Schemas.Types;
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
using XenoTerra.DataAccessLayer.Repositories.Entity.LikeRepository;
using XenoTerra.DataAccessLayer.Repositories.Entity.MediaRepository;
using XenoTerra.DataAccessLayer.Repositories.Entity.MessageRepository;
using XenoTerra.DataAccessLayer.Repositories.Entity.NoteRepository;
using XenoTerra.DataAccessLayer.Repositories.Entity.NotificationRepository;
using XenoTerra.DataAccessLayer.Repositories.Entity.PostRepository;
using XenoTerra.DataAccessLayer.Repositories.Entity.ReactionRepository;
using XenoTerra.DataAccessLayer.Repositories.Entity.RecentChatsRepository;
using XenoTerra.DataAccessLayer.Repositories.Entity.ReportCommentRepository;
using XenoTerra.DataAccessLayer.Repositories.Entity.RoleRepository;
using XenoTerra.DataAccessLayer.Repositories.Entity.SavedPostRepository;
using XenoTerra.DataAccessLayer.Repositories.Entity.SearchHistoryRepository;
using XenoTerra.DataAccessLayer.Repositories.Entity.StoryRepository;
using XenoTerra.DataAccessLayer.Repositories.Entity.UserRepository;
using XenoTerra.DataAccessLayer.Repositories.Entity.UserSettingRepository;
using XenoTerra.DataAccessLayer.Repositories.Entity.ViewStoryRepository;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.DataAccessLayer.Repositories.Generic.Write;
using XenoTerra.WebAPI.Schemas.DataLoaders.DataLoaderFactories;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.BlockUserResolvers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.HighlightResolvers;
using XenoTerra.WebAPI.Schemas.Queries.BlockUserQueries;
using XenoTerra.WebAPI.Schemas.Queries.CommentQueries;
using XenoTerra.WebAPI.Schemas.Queries.FollowQueries;
using XenoTerra.WebAPI.Schemas.Queries.LikeQueries;
using XenoTerra.WebAPI.Schemas.Queries.MediaQueries;
using XenoTerra.WebAPI.Schemas.Queries.MessageQueries;
using XenoTerra.WebAPI.Schemas.Queries.NoteQueries;
using XenoTerra.WebAPI.Schemas.Queries.NotificationQueries;
using XenoTerra.WebAPI.Schemas.Queries.PostQueries;
using XenoTerra.WebAPI.Schemas.Queries.ReactionQueries;
using XenoTerra.WebAPI.Schemas.Queries.RecentChatsQueries;
using XenoTerra.WebAPI.Schemas.Queries.ReportCommentQueries;
using XenoTerra.WebAPI.Schemas.Queries.RoleQueries;
using XenoTerra.WebAPI.Schemas.Queries.SavedPostQueries;
using XenoTerra.WebAPI.Schemas.Queries.SearchHistoryQueries;
using XenoTerra.WebAPI.Schemas.Queries.StoryQueries;
using XenoTerra.WebAPI.Schemas.Queries.UserQueries;
using XenoTerra.WebAPI.Schemas.Queries.UserSettingQueries;
using XenoTerra.WebAPI.Schemas.Queries.ViewStoryQueries;
using XenoTerra.WebAPI.Schemas.Queries.HighlightQueries;
using XenoTerra.WebAPI.Services.Queries.Entity.BlockUserQueryServices;
using XenoTerra.WebAPI.Services.Queries.Entity.CommentQueryServices;
using XenoTerra.WebAPI.Services.Queries.Entity.FollowQueryServices;
using XenoTerra.WebAPI.Services.Queries.Entity.HighlightQueryServices;
using XenoTerra.WebAPI.Services.Queries.Entity.LikeQueryServices;
using XenoTerra.WebAPI.Services.Queries.Entity.MediaQueryServices;
using XenoTerra.WebAPI.Services.Queries.Entity.MessageQueryServices;
using XenoTerra.WebAPI.Services.Queries.Entity.NoteQueryServices;
using XenoTerra.WebAPI.Services.Queries.Entity.NotificationQueryServices;
using XenoTerra.WebAPI.Services.Queries.Entity.PostQueryServices;
using XenoTerra.WebAPI.Services.Queries.Entity.ReactionQueryServices;
using XenoTerra.WebAPI.Services.Queries.Entity.RecentChatsQueryServices;
using XenoTerra.WebAPI.Services.Queries.Entity.ReportCommentQueryServices;
using XenoTerra.WebAPI.Services.Queries.Entity.RoleQueryServices;
using XenoTerra.WebAPI.Services.Queries.Entity.SavedPostQueryServices;
using XenoTerra.WebAPI.Services.Queries.Entity.SearchHistoryQueryServices;
using XenoTerra.WebAPI.Services.Queries.Entity.SearchHistoryUserQueryServices;
using XenoTerra.WebAPI.Services.Queries.Entity.StoryHighlightQueryServices;
using XenoTerra.WebAPI.Services.Queries.Entity.StoryQueryServices;
using XenoTerra.WebAPI.Services.Queries.Entity.UserPostTagQueryServices;
using XenoTerra.WebAPI.Services.Queries.Entity.UserQueryServices;
using XenoTerra.WebAPI.Services.Queries.Entity.UserSettingQueryServices;
using XenoTerra.WebAPI.Services.Queries.Entity.ViewStoryQueryServices;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.BussinessLogicLayer.Services.Generic.Write;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.CommentResolvers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.FollowResolvers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.LikeResolvers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.MediaResolvers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.MessageResolvers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.NoteResolvers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.NotificationResolvers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.PostResolvers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.ReactionResolvers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.RecentChatsResolvers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.ReportCommentResolvers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.RoleResolvers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.SavedPostResolvers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.SearchHistoryResolvers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.StoryResolvers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.UserResolvers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.UserSettingResolvers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.ViewStoryResolvers;
using XenoTerra.WebAPI.Schemas.Resolvers;
using XenoTerra.WebAPI.Schemas.Resolvers.Base;
using XenoTerra.WebAPI.Schemas.DataLoaders.Entity;

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
                .AddDataLoader<StoryDataLoader>();

            builder.Services.AddScoped<BlockUserQuery>();
            builder.Services.AddScoped<CommentQuery>();
            builder.Services.AddScoped<FollowQuery>();
            builder.Services.AddScoped<HighlightQuery>();
            builder.Services.AddScoped<LikeQuery>();
            builder.Services.AddScoped<MediaQuery>();
            builder.Services.AddScoped<MessageQuery>();
            builder.Services.AddScoped<NoteQuery>();
            builder.Services.AddScoped<NotificationQuery>();
            builder.Services.AddScoped<PostQuery>();
            builder.Services.AddScoped<ReactionQuery>();
            builder.Services.AddScoped<RecentChatsQuery>();
            builder.Services.AddScoped<ReportCommentQuery>();
            builder.Services.AddScoped<RoleQuery>();
            builder.Services.AddScoped<SavedPostQuery>();
            builder.Services.AddScoped<SearchHistoryQuery>();
            builder.Services.AddScoped<StoryQuery>();
            builder.Services.AddScoped<UserQuery>();
            builder.Services.AddScoped<UserSettingQuery>();
            builder.Services.AddScoped<ViewStoryQuery>();


            builder.Services.AddScoped(typeof(EntityDataLoaderFactory));
            builder.Services.AddScoped(typeof(IEntityResolver<,,>), typeof(EntityResolver<,,>));
            builder.Services.AddScoped<BlockUserResolver>();
            builder.Services.AddScoped<HighlightResolver>();


            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            builder.Services.AddAutoMapper(typeof(GeneralMapping));


            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Scoped);

            builder.Services.AddScoped(typeof(IReadService<,,>), typeof(ReadService<,,>));
            builder.Services.AddScoped(typeof(IWriteService<,,,,>), typeof(WriteService<,,,,>));

            builder.Services.AddScoped(typeof(IReadRepository<,,>), typeof(ReadRepository<,,>));
            builder.Services.AddScoped(typeof(IWriteRepository<,,>), typeof(WriteRepository<,,>));




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

            builder.Services.AddScoped<IBlockUserQueryService, BlockUserQueryService>();
            builder.Services.AddScoped<ICommentQueryService, CommentQueryService>();
            builder.Services.AddScoped<IFollowQueryService, FollowQueryService>();
            builder.Services.AddScoped<IHighlightQueryService, HighlightQueryService>();
            builder.Services.AddScoped<ILikeQueryService, LikeQueryService>();
            builder.Services.AddScoped<IMediaQueryService, MediaQueryService>();
            builder.Services.AddScoped<IMessageQueryService, MessageQueryService>();
            builder.Services.AddScoped<INoteQueryService, NoteQueryService>();
            builder.Services.AddScoped<INotificationQueryService, NotificationQueryService>();
            builder.Services.AddScoped<IPostQueryService, PostQueryService>();
            builder.Services.AddScoped<IUserPostTagQueryService, UserPostTagQueryService>();
            builder.Services.AddScoped<IReactionQueryService, ReactionQueryService>();
            builder.Services.AddScoped<IRecentChatsQueryService, RecentChatsQueryService>();
            builder.Services.AddScoped<IReportCommentQueryService, ReportCommentQueryService>();
            builder.Services.AddScoped<IRoleQueryService, RoleQueryService>();
            builder.Services.AddScoped<ISavedPostQueryService, SavedPostQueryService>();
            builder.Services.AddScoped<ISearchHistoryQueryService, SearchHistoryQueryService>();
            builder.Services.AddScoped<ISearchHistoryUserQueryService, SearchHistoryUserQueryService>();
            builder.Services.AddScoped<IStoryHighlightQueryService, StoryHighlightQueryService>();
            builder.Services.AddScoped<IStoryQueryService, StoryQueryService>();
            builder.Services.AddScoped<IUserQueryService, UserQueryService>();
            builder.Services.AddScoped<IUserSettingQueryService, UserSettingQueryService>();
            builder.Services.AddScoped<IViewStoryQueryService, ViewStoryQueryService>();

            builder.Services.AddScoped<IBlockUserResolver, BlockUserResolver>();
            builder.Services.AddScoped<ICommentResolver, CommentResolver>();
            builder.Services.AddScoped<IFollowResolver, FollowResolver>();
            builder.Services.AddScoped<IHighlightResolver, HighlightResolver>();
            builder.Services.AddScoped<ILikeResolver, LikeResolver>();
            builder.Services.AddScoped<IMediaResolver, MediaResolver>();
            builder.Services.AddScoped<IMessageResolver, MessageResolver>();
            builder.Services.AddScoped<INoteResolver, NoteResolver>();
            builder.Services.AddScoped<INotificationResolver, NotificationResolver>();
            builder.Services.AddScoped<IPostResolver, PostResolver>();
            builder.Services.AddScoped<IReactionResolver, ReactionResolver>();
            builder.Services.AddScoped<IRecentChatsResolver, RecentChatsResolver>();
            builder.Services.AddScoped<IReportCommentResolver, ReportCommentResolver>();
            builder.Services.AddScoped<IRoleResolver, RoleResolver>();
            builder.Services.AddScoped<ISavedPostResolver, SavedPostResolver>();
            builder.Services.AddScoped<ISearchHistoryResolver, SearchHistoryResolver>();
            builder.Services.AddScoped<IStoryResolver, StoryResolver>();
            builder.Services.AddScoped<IUserResolver, UserResolver>();
            builder.Services.AddScoped<IUserSettingResolver, UserSettingResolver>();
            builder.Services.AddScoped<IViewStoryResolver, ViewStoryResolver>();

            builder.Services.AddScoped<BlockUserDataLoader>();
            builder.Services.AddScoped<CommentDataLoader>();
            builder.Services.AddScoped<FollowDataLoader>();
            builder.Services.AddScoped<HighlightDataLoader>();
            builder.Services.AddScoped<LikeDataLoader>();
            builder.Services.AddScoped<MediaDataLoader>();
            builder.Services.AddScoped<MessageDataLoader>();
            builder.Services.AddScoped<NoteDataLoader>();
            builder.Services.AddScoped<NotificationDataLoader>();
            builder.Services.AddScoped<ReactionDataLoader>();
            builder.Services.AddScoped<RecentChatsDataLoader>();
            builder.Services.AddScoped<ReportCommentDataLoader>();
            builder.Services.AddScoped<RoleDataLoader>();
            builder.Services.AddScoped<SavedPostDataLoader>();
            builder.Services.AddScoped<SearchHistoryDataLoader>();
            builder.Services.AddScoped<StoryDataLoader>();
            builder.Services.AddScoped<UserDataLoader>();
            builder.Services.AddScoped<UserSettingDataLoader>();
            builder.Services.AddScoped<ViewStoryDataLoader>();
        }
    }
}