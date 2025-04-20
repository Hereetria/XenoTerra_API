using Microsoft.EntityFrameworkCore;
using XenoTerra.DTOLayer.Mappings;
using System.Reflection;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.BlockUserResolvers;
using XenoTerra.WebAPI.Services.Common.EntityMapping;
using XenoTerra.WebAPI.Services.Common.DataLoading;
using XenoTerra.WebAPI.Services.Common.EntityAssignment;
using XenoTerra.WebAPI.GraphQL.Schemas;
using XenoTerra.DataAccessLayer.Repositories.Base.Read;
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.BussinessLogicLayer.Services.Base.Read;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers;
using XenoTerra.WebAPI.Services.Queries.Base;
using XenoTerra.WebAPI.GraphQL.Resolvers.Base;
using XenoTerra.WebAPI.GraphQL.Extensions.Configurators;
using XenoTerra.WebAPI.GraphQL.Extensions.Builders;
using XenoTerra.WebAPI.GraphQL.DataLoaders.Factories;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.HighlightResolvers;

namespace XenoTerra.WebAPI.Extensions
{
    public static class AppServiceConfigurator
    {
        public static void ConfigureServices(WebApplicationBuilder builder)
        {
            var executorBuilder = builder.Services.AddGraphQLServer();
            var graphqlBuilder = new GraphQLEntityBuilder(builder.Services, executorBuilder);
            GraphQLConfigurator.ConfigureEntityModules(graphqlBuilder);

            builder.Services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddSubscriptionType<Subscription>()
                .AddInMemorySubscriptions()
                .AddFiltering()
                .AddSorting()
                .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true);

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
        }
    }
}