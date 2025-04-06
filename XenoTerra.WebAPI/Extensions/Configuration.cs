using Microsoft.EntityFrameworkCore;
using XenoTerra.DTOLayer.Mappings;
using System.Reflection;
using XenoTerra.WebAPI.Schemas.DataLoaders.DataLoaderFactories;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.BlockUserResolvers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.HighlightResolvers;
using XenoTerra.WebAPI.Schemas.Resolvers.Base;
using XenoTerra.WebAPI.Services.Common.EntityMapping;
using XenoTerra.WebAPI.Services.Common.DataLoading;
using XenoTerra.WebAPI.Services.Common.EntityAssignment;
using XenoTerra.DataAccessLayer.Repositories.Entity.BlockUserRepository;
using XenoTerra.BussinessLogicLayer.Services.Entity.BlockUserService;
using XenoTerra.WebAPI.Services.Queries.Entity.BlockUserQueryServices;
using XenoTerra.WebAPI.Extensions.Helpers;
using XenoTerra.WebAPI.GraphQL.Schemas;
using XenoTerra.DataAccessLayer.Repositories.Base.Read;
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.BussinessLogicLayer.Services.Base.Read;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.WebAPI.Extensions.Helpers.Strategies.Abstract;
using XenoTerra.WebAPI.Extensions.Helpers.Strategies;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers;
using XenoTerra.WebAPI.Services.Queries.Base;
using XenoTerra.WebAPI.Schemas.DataLoaders.Entity;
using XenoTerra.WebAPI.Services.Queries.Entity.HighlightQueryServices;
using XenoTerra.WebAPI.Services.Queries.Entity.StoryQueryServices;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.StoryResolvers;
using XenoTerra.WebAPI.GraphQL.DataLoaders.Entity;
using XenoTerra.WebAPI.Services.Queries.Entity.UserQueryServices;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.UserResolvers;
using XenoTerra.WebAPI.Services.Mutations.Entity.BlockUserMutationServices;
using HotChocolate.Execution;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Subscriptions;
using XenoTerra.WebAPI.GraphQL;

namespace XenoTerra.WebAPI.Extensions
{
    public static class Configuration
    {
        public static void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddSubscriptionType<BlockUserSubscription>()
                .AddInMemorySubscriptions()
                .AddProjections()
                .AddFiltering()
                .AddSorting();

            builder.Services.AddScoped<BlockUserSubscription>();

            builder.Services.AddAllDataLoaders(typeof(Query).Assembly);
            builder.Services.AddAllObjectTypes(typeof(Query).Assembly);

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")),
                ServiceLifetime.Scoped);

            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            builder.Services.AddAutoMapper(typeof(GeneralMapping).Assembly);

            builder.Services.AddScoped(typeof(IReadService<,>), typeof(ReadService<,>));
            builder.Services.AddScoped(typeof(IWriteService<,,,>), typeof(WriteService<,,,>));
            builder.Services.AddScoped(typeof(IReadRepository<,>), typeof(ReadRepository<,>));
            builder.Services.AddScoped(typeof(IWriteRepository<,>), typeof(WriteRepository<,>));

            builder.Services.AddScoped(typeof(EntityDataLoaderFactory));
            builder.Services.AddScoped(typeof(IEntityResolver<,>), typeof(EntityResolver<,>));
            builder.Services.AddScoped<BlockUserResolver>();
            builder.Services.AddScoped<HighlightResolver>();

            builder.Services.AddScoped(typeof(IEntityFieldMapBuilder<,>), typeof(EntityFieldMapBuilder<,>));
            builder.Services.AddScoped(typeof(IEntityAssignmentService<,,>), typeof(EntityAssignmentService<,,>));
            builder.Services.AddScoped(typeof(IDataLoaderInvoker), typeof(DataLoaderInvoker));

            builder.Services.AddScoped(typeof(IQueryService<,>), typeof(QueryService<,>));
            builder.Services.AddScoped(typeof(IQueryResolverHelper<,>), typeof(QueryResolverHelper<,>));




            builder.Services.AddScoped(typeof(IBlockUserQueryService), typeof(BlockUserQueryService));
            builder.Services.AddScoped(typeof(IBlockUserResolver), typeof(BlockUserResolver));
            builder.Services.AddScoped(typeof(BlockUserDataLoader));

            builder.Services.AddScoped(typeof(IUserQueryService), typeof(UserQueryService));
            builder.Services.AddScoped(typeof(IUserResolver), typeof(UserResolver));
            builder.Services.AddScoped(typeof(UserDataLoader));

            builder.Services.AddScoped(typeof(IHighlightQueryService), typeof(HighlightQueryService));
            builder.Services.AddScoped(typeof(IHighlightResolver), typeof(HighlightResolver));
            builder.Services.AddScoped(typeof(HighlightDataLoader));

            builder.Services.AddScoped(typeof(IStoryQueryService), typeof(StoryQueryService));
            builder.Services.AddScoped(typeof(IStoryResolver), typeof(StoryResolver));
            builder.Services.AddScoped(typeof(StoryDataLoader));

            builder.Services.AddScoped(typeof(IBlockUserMutationService), typeof(BlockUserMutationService));
            builder.Services.AddScoped(typeof(IBlockUserWriteService), typeof(BlockUserWriteService));

            builder.Services.AddScoped(typeof(BlockUserSubscription));

            var targetAssemblies = new[]
            {
            typeof(IBlockUserReadRepository).Assembly, // DataAccessLayer
            typeof(IBlockUserReadService).Assembly,    // BussinessLogicLayer
            typeof(IBlockUserQueryService).Assembly    // WebApi
        };

            builder.Services.RegisterAllScopedServices(
                targetAssemblies,
        [
            new InterfaceToImplementationStrategy(),
            new GenericTypeStrategy(),
            new ConcreteTypeStrategy()
        ]);
        }
    }
}