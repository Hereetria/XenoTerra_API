using XenoTerra.DataAccessLayer.Contexts;
using Microsoft.EntityFrameworkCore;
using XenoTerra.DTOLayer.Mappings;
using System.Reflection;
using XenoTerra.WebAPI.Schemas.Mutations;
using XenoTerra.WebAPI.Schemas.Queries;
using XenoTerra.WebAPI.Schemas.Types;
using XenoTerra.BussinessLogicLayer.Services.Entity.ReportCommentService;
using XenoTerra.BussinessLogicLayer.Services.Entity.UserService;
using XenoTerra.DataAccessLayer.Repositories.Entity.CommentRepository;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.DataAccessLayer.Repositories.Generic.Write;
using XenoTerra.WebAPI.Schemas.DataLoaders.DataLoaderFactories;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.BlockUserResolvers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.HighlightResolvers;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.BussinessLogicLayer.Services.Generic.Write;
using XenoTerra.WebAPI.Schemas.Resolvers.Base;
using XenoTerra.WebAPI.Schemas.DataLoaders.Entity;
using XenoTerra.WebAPI.Services.Common.EntityMapping;
using XenoTerra.WebAPI.Services.Common.DataLoading;
using XenoTerra.WebAPI.Services.Common.EntityAssignment;
using XenoTerra.DataAccessLayer.Repositories.Entity.BlockUserRepository;
using XenoTerra.BussinessLogicLayer.Services.Entity.BlockUserService;
using XenoTerra.WebAPI.Services.Queries.Entity.BlockUserQueryServices;
using XenoTerra.WebAPI.Extensions.Helpers;

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
                .AddProjections()
                .AddFiltering()
                .AddSorting();

            builder.Services.AddAllDataLoaders(typeof(Query).Assembly);
            builder.Services.AddAllObjectTypes(typeof(Query).Assembly);

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")),
                ServiceLifetime.Scoped);

            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            builder.Services.AddAutoMapper(typeof(GeneralMapping));

            builder.Services.AddScoped(typeof(IReadService<,>), typeof(ReadService<,>));
            builder.Services.AddScoped(typeof(IWriteService<,,,,>), typeof(WriteService<,,,,>));
            builder.Services.AddScoped(typeof(IReadRepository<,>), typeof(ReadRepository<,>));
            builder.Services.AddScoped(typeof(IWriteRepository<,,>), typeof(WriteRepository<,,>));

            builder.Services.AddScoped(typeof(EntityDataLoaderFactory));
            builder.Services.AddScoped(typeof(IEntityResolver<,>), typeof(EntityResolver<,>));
            builder.Services.AddScoped<BlockUserResolver>();
            builder.Services.AddScoped<HighlightResolver>();

            builder.Services.AddScoped(typeof(IEntityFieldMapBuilder<,>), typeof(EntityFieldMapBuilder<,>));
            builder.Services.AddScoped(typeof(IEntityAssignmentService<,,>), typeof(EntityAssignmentService<,,>));
            builder.Services.AddScoped(typeof(IDataLoaderInvoker), typeof(DataLoaderInvoker));


            var targetAssemblies = new[]
            {
            typeof(IBlockUserReadRepository).Assembly, // DataAccessLayer
            typeof(IBlockUserReadService).Assembly,    // BussinessLogicLayer
            typeof(IBlockUserQueryService).Assembly    // WebApi
        };

            builder.Services.RegisterAllScopedServices(targetAssemblies);
        }
    }
}