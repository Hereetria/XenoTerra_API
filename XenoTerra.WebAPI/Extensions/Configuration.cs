using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using XenoTerra.DataAccessLayer.Contexts;
using Microsoft.EntityFrameworkCore;
using XenoTerra.DTOLayer.Mappings;
using System.Reflection;
using XenoTerra.BussinessLogicLayer.Services.BlockUserServices;
using XenoTerra.BussinessLogicLayer.Services.CommentServices;
using XenoTerra.BussinessLogicLayer.Services.FollowServices;
using XenoTerra.BussinessLogicLayer.Services.HighlightServices;
using XenoTerra.BussinessLogicLayer.Services.LikeServices;
using XenoTerra.BussinessLogicLayer.Services.MediaServices;
using XenoTerra.BussinessLogicLayer.Services.MessageServices;
using XenoTerra.BussinessLogicLayer.Services.NoteServices;
using XenoTerra.BussinessLogicLayer.Services.NotificationServices;
using XenoTerra.BussinessLogicLayer.Services.PostServices;
using XenoTerra.BussinessLogicLayer.Services.ReactionServices;
using XenoTerra.BussinessLogicLayer.Services.RecentChatsServices;
using XenoTerra.BussinessLogicLayer.Services.ReportCommentServices;
using XenoTerra.BussinessLogicLayer.Services.SavedPostServices;
using XenoTerra.BussinessLogicLayer.Services.SearchHistoryServices;
using XenoTerra.BussinessLogicLayer.Services.StoryServices;
using XenoTerra.BussinessLogicLayer.Services.UserServices;
using XenoTerra.BussinessLogicLayer.Services.UserSettingServices;
using XenoTerra.BussinessLogicLayer.Services.ViewStoryServices;
using XenoTerra.DataAccessLayer.Factories.Abstract;
using XenoTerra.DataAccessLayer.Factories.Concrete;
using XenoTerra.DataAccessLayer.Repositories;
using XenoTerra.DataAccessLayer.Services.BlockUserServices;
using XenoTerra.DataAccessLayer.Services.CommentServices;
using XenoTerra.DataAccessLayer.Services.FollowServices;
using XenoTerra.DataAccessLayer.Services.HighlightServices;
using XenoTerra.DataAccessLayer.Services.LikeServices;
using XenoTerra.DataAccessLayer.Services.MediaServices;
using XenoTerra.DataAccessLayer.Services.MessageServices;
using XenoTerra.DataAccessLayer.Services.NoteServices;
using XenoTerra.DataAccessLayer.Services.NotificationServices;
using XenoTerra.DataAccessLayer.Services.PostServices;
using XenoTerra.DataAccessLayer.Services.ReactionServices;
using XenoTerra.DataAccessLayer.Services.RecentChatsServices;
using XenoTerra.DataAccessLayer.Services.ReportCommentServices;
using XenoTerra.DataAccessLayer.Services.SavedPostServices;
using XenoTerra.DataAccessLayer.Services.SearchHistoryServices;
using XenoTerra.DataAccessLayer.Services.StoryServices;
using XenoTerra.DataAccessLayer.Services.UserServices;
using XenoTerra.DataAccessLayer.Services.UserSettingServices;
using XenoTerra.DataAccessLayer.Services.ViewStoryServices;
using XenoTerra.DataAccessLayer.Services.RoleServices;
using XenoTerra.BussinessLogicLayer.Services.RoleServices;
using XenoTerra.WebAPI.Schemas.Mutations;
using XenoTerra.WebAPI.Schemas.Queries;
using XenoTerra.BussinessLogicLayer.Services.PostTagServices;
using XenoTerra.BussinessLogicLayer.Services.SearchHistoryUserServices;
using XenoTerra.DataAccessLayer.Services.PostTagServices;
using XenoTerra.DataAccessLayer.Services.SearchHistoryUserServices;
using XenoTerra.WebAPI.Schemas.Types;
using XenoTerra.WebAPI.Schemas.DataLoaders;
using XenoTerra.WebAPI.Schemas.Resolvers;

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
                .AddProjections()
                .AddFiltering()
                .AddDataLoader<UserDataLoader>();


            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            builder.Services.AddAutoMapper(typeof(GeneralMapping));


            builder.Services.AddDbContextFactory<Context>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                sqlOptions => sqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));

            builder.Services.AddScoped<IGenericRepositoryDALFactory, GenericRepositoryDALFactory>();
            builder.Services.AddScoped(typeof(IGenericRepositoryDAL<,,,,,>), typeof(GenericRepositoryDAL<,,,,,>));

            builder.Services.AddScoped<BlockUserResolver>();


            builder.Services.AddScoped<IBlockUserServiceBLL, BlockUserServiceBLL>();
            builder.Services.AddScoped<IBlockUserServiceDAL, BlockUserServiceDAL>();

            builder.Services.AddScoped<ICommentServiceBLL, CommentServiceBLL>();
            builder.Services.AddScoped<ICommentServiceDAL, CommentServiceDAL>();

            builder.Services.AddScoped<IFollowServiceBLL, FollowServiceBLL>();
            builder.Services.AddScoped<IFollowServiceDAL, FollowServiceDAL>();

            builder.Services.AddScoped<IHighlightServiceBLL, HighlightServiceBLL>();
            builder.Services.AddScoped<IHighlightServiceDAL, HighlightServiceDAL>();

            builder.Services.AddScoped<ILikeServiceBLL, LikeServiceBLL>();
            builder.Services.AddScoped<ILikeServiceDAL, LikeServiceDAL>();

            builder.Services.AddScoped<IMediaServiceBLL, MediaServiceBLL>();
            builder.Services.AddScoped<IMediaServiceDAL, MediaServiceDAL>();

            builder.Services.AddScoped<IMessageServiceBLL, MessageServiceBLL>();
            builder.Services.AddScoped<IMessageServiceDAL, MessageServiceDAL>();

            builder.Services.AddScoped<INoteServiceBLL, NoteServiceBLL>();
            builder.Services.AddScoped<INoteServiceDAL, NoteServiceDAL>();

            builder.Services.AddScoped<INotificationServiceBLL, NotificationServiceBLL>();
            builder.Services.AddScoped<INotificationServiceDAL, NotificationServiceDAL>();

            builder.Services.AddScoped<IPostServiceBLL, PostServiceBLL>();
            builder.Services.AddScoped<IPostServiceDAL, PostServiceDAL>();

            builder.Services.AddScoped<IPostTagServiceBLL, PostTagServiceBLL>(); 
            builder.Services.AddScoped<IPostTagServiceDAL, PostTagServiceDAL>();

            builder.Services.AddScoped<IReactionServiceBLL, ReactionServiceBLL>();
            builder.Services.AddScoped<IReactionServiceDAL, ReactionServiceDAL>();

            builder.Services.AddScoped<IRecentChatsServiceBLL, RecentChatsServiceBLL>();
            builder.Services.AddScoped<IRecentChatsServiceDAL, RecentChatsServiceDAL>();

            builder.Services.AddScoped<IReportCommentServiceBLL, ReportCommentServiceBLL>();
            builder.Services.AddScoped<IReportCommentServiceDAL, ReportCommentServiceDAL>();

            builder.Services.AddScoped<IRoleServiceBLL, RoleServiceBLL>();
            builder.Services.AddScoped<IRoleServiceDAL, RoleServiceDAL>();

            builder.Services.AddScoped<ISavedPostServiceBLL, SavedPostServiceBLL>();
            builder.Services.AddScoped<ISavedPostServiceDAL, SavedPostServiceDAL>();

            builder.Services.AddScoped<ISearchHistoryServiceBLL, SearchHistoryServiceBLL>();
            builder.Services.AddScoped<ISearchHistoryServiceDAL, SearchHistoryServiceDAL>();

            builder.Services.AddScoped<ISearchHistoryUserServiceBLL, SearchHistoryUserServiceBLL>(); 
            builder.Services.AddScoped<ISearchHistoryUserServiceDAL, SearchHistoryUserServiceDAL>(); 

            builder.Services.AddScoped<IStoryServiceBLL, StoryServiceBLL>();
            builder.Services.AddScoped<IStoryServiceDAL, StoryServiceDAL>();

            builder.Services.AddScoped<IUserServiceBLL, UserServiceBLL>();
            builder.Services.AddScoped<IUserServiceDAL, UserServiceDAL>();

            builder.Services.AddScoped<IUserSettingServiceBLL, UserSettingServiceBLL>();
            builder.Services.AddScoped<IUserSettingServiceDAL, UserSettingServiceDAL>();

            builder.Services.AddScoped<IViewStoryServiceBLL, ViewStoryServiceBLL>();
            builder.Services.AddScoped<IViewStoryServiceDAL, ViewStoryServiceDAL>();

        }
    }
}