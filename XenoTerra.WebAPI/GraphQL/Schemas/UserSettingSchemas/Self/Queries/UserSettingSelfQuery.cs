using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.UserSettingDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.UserSettingQueryServices;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.UserSettingResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Queries.Sorts;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using System.Linq.Expressions;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Queries
{
    [Authorize(Roles = new[] { nameof(Roles.User), nameof(Roles.Admin) })]
    public class UserSettingSelfQuery(IMapper mapper, IQueryResolverHelper<UserSetting, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<UserSetting, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(UserSettingSelfFilterType))]
        [UseSorting(typeof(UserSettingSelfSortType))]
        public async Task<UserSettingSelfConnection> GetAllUserSettingsAsync(
            [Service] IUserSettingQueryService service,
            [Service] IUserSettingResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var filter = CreateUserSettingAccessFilter(currentUserId);

            var query = service.GetAllQueryable(context).Where(filter);
            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<UserSetting, ResultUserSettingWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<UserSettingSelfConnection, ResultUserSettingWithRelationsDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(UserSettingSelfFilterType))]
        [UseSorting(typeof(UserSettingSelfSortType))]
        public async Task<UserSettingSelfConnection> GetUserSettingsByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IUserSettingQueryService service,
            [Service] IUserSettingResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var filter = CreateUserSettingAccessFilter(currentUserId);

            var query = service.GetByIdsQueryable(parsedKeys, context).Where(filter);
            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<UserSetting, ResultUserSettingWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<UserSettingSelfConnection, ResultUserSettingWithRelationsDto>(connection);
        }

        public async Task<ResultUserSettingWithRelationsDto?> GetUserSettingByIdAsync(
            string? key,
            [Service] IUserSettingQueryService service,
            [Service] IUserSettingResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var filter = CreateUserSettingAccessFilter(currentUserId);

            var query = service.GetByIdQueryable(parsedKey, context).Where(filter);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultUserSettingWithRelationsDto>(entity);
        }

        private static Expression<Func<UserSetting, bool>> CreateUserSettingAccessFilter(Guid currentUserId) =>
            setting => setting.UserId == currentUserId;
    }
}
