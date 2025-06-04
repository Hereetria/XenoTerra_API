using Microsoft.EntityFrameworkCore;
using XenoTerra.DTOLayer.Mappings;
using System.Reflection;
using XenoTerra.WebAPI.Services.Common.EntityMapping;
using XenoTerra.WebAPI.Services.Common.DataLoading;
using XenoTerra.WebAPI.Services.Common.EntityAssignment;
using XenoTerra.DataAccessLayer.Repositories.Base.Read;
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.BussinessLogicLayer.Services.Base.Read;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.WebAPI.Services.Queries.Base;
using XenoTerra.WebAPI.GraphQL.Resolvers.Base;
using XenoTerra.WebAPI.GraphQL.Extensions.Configurators;
using XenoTerra.WebAPI.GraphQL.Extensions.Builders;
using XenoTerra.WebAPI.GraphQL.DataLoaders.Factories;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.HighlightResolvers;
using Microsoft.AspNetCore.Identity;
using XenoTerra.EntityLayer.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using XenoTerra.WebAPI.GraphQL.Auth.Services;
using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Auth.Inputs;
using XenoTerra.WebAPI.GraphQL.Auth.Validators;
using System.Security.Claims;
using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas._RootMutations;
using XenoTerra.WebAPI.GraphQL.Schemas._RootQueries;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.BlockUserResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Concrete;
using Microsoft.AspNetCore.Authentication;
using XenoTerra.WebAPI.GraphQL.Auth;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Extensions
{
    public static class AppServiceConfigurator
    {
        public static void ConfigureServices(WebApplicationBuilder builder)
        {
            var executorBuilder = builder.Services.AddGraphQLServer();
            var graphqlBuilder = new GraphQLEntityBuilder(builder.Services, executorBuilder);
            GraphQLConfigurator.ConfigureEntityModules(graphqlBuilder);

            builder.Services.AddAuthorization();

            executorBuilder
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddSubscriptionType<Subscription>()
                .AddInMemorySubscriptions()
                .AddFiltering()
                .AddSorting()
                .AddAuthorization()
                .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true);

            builder.Services.AddScoped<Query>();
            builder.Services.AddScoped<AdminQuery>();
            builder.Services.AddScoped<UserQuery>();

            builder.Services.AddScoped<Mutation>();
            builder.Services.AddScoped<AdminMutation>();
            builder.Services.AddScoped<UserMutation>();

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")),
                ServiceLifetime.Scoped);

            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            builder.Services.AddAutoMapper(typeof(GeneralMapping).Assembly);

            builder.Services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();


            if (builder.Environment.IsDevelopment())
            {
                builder.Services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = "DevScheme";
                    options.DefaultChallengeScheme = "DevScheme";
                })
                .AddScheme<AuthenticationSchemeOptions, DevAuthenticationHandler>("DevScheme", options => { });
            }
            else
            {
                var jwtSection = builder.Configuration.GetSection("JwtSettings");
                var secretKey = jwtSection["SecretKey"]
                    ?? throw new InvalidOperationException("JWT SecretKey is missing in configuration.");
                var issuer = jwtSection["Issuer"]
                    ?? throw new InvalidOperationException("JWT Issuer is missing.");
                var audience = jwtSection["Audience"]
                    ?? throw new InvalidOperationException("JWT Audience is missing.");

                var signingKey = secretKey.Length >= 64
                    ? new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                    : throw new ArgumentException("The secret key must be at least 64 characters long.", nameof(secretKey));

                builder.Services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = issuer,
                        ValidAudience = audience,
                        IssuerSigningKey = signingKey,

                        ClockSkew = TimeSpan.Zero,
                        RoleClaimType = ClaimTypes.Role
                    };
                });
            }


            builder.Services.AddScoped(typeof(IAuthService), typeof(AuthService));
            builder.Services.AddScoped<IValidator<LoginInput>, LoginInputValidator>();
            builder.Services.AddScoped<IValidator<RegisterInput>, RegisterInputValidator>();


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

            builder.Services.AddScoped<IBlockedUserIdProvider, BlockedUserIdProvider>();
            builder.Services.AddScoped<IFollowedUserIdProvider, FollowedUserIdProvider>();
            builder.Services.AddScoped<IPublicUserIdProvider, PublicUserIdProvider>();
            builder.Services.AddScoped(typeof(IQueryResolverHelper<,>), typeof(QueryResolverHelper<,>));

            builder.Services.AddScoped(typeof(IQueryService<,>), typeof(QueryService<,>));
            builder.Services.AddScoped(typeof(IMutationService<,,,,>), typeof(MutationService<,,,,>));
        }
    }
}