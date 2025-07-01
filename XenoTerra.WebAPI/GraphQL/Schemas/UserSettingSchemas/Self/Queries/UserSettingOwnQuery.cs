using AutoMapper;
using HotChocolate.Authorization;
using HotChocolate.Resolvers;
using System.Linq.Expressions;
using XenoTerra.DTOLayer.Dtos.UserSettingDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.UserSettingResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Queries.Paginations.Own;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.UserSettingQueryServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class UserSettingOwnQuery(IMapper mapper, IQueryResolverHelper<UserSetting, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<UserSetting, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(UserSettingOwnFilterType))]
        [UseSorting(typeof(UserSettingOwnSortType))]
        public async Task<UserSettingOwnConnection> GetAllSearchHistoriesAsync(
            [Service] IUserSettingQueryService service,
            [Service] IUserSettingResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var filter = CreateUserSettingAccessFilter(httpContextAccessor);
            var query = service.GetAllQueryable(context, filter);

            var entityOwnConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<UserSetting, ResultUserSettingWithRelationsOwnDto>(
                entityOwnConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<UserSettingOwnConnection, ResultUserSettingWithRelationsOwnDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(UserSettingOwnFilterType))]
        [UseSorting(typeof(UserSettingOwnSortType))]
        public async Task<UserSettingOwnConnection> GetSearchHistoriesByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IUserSettingQueryService service,
            [Service] IUserSettingResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));
            var filter = CreateUserSettingAccessFilter(httpContextAccessor);
            var query = service.GetByIdsQueryable(parsedKeys, context, filter);

            var entityOwnConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<UserSetting, ResultUserSettingWithRelationsOwnDto>(
                entityOwnConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<UserSettingOwnConnection, ResultUserSettingWithRelationsOwnDto>(connection);
        }

        public async Task<ResultUserSettingWithRelationsOwnDto?> GetUserSettingByIdAsync(
            string? key,
            [Service] IUserSettingQueryService service,
            [Service] IUserSettingResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));
            var filter = CreateUserSettingAccessFilter(httpContextAccessor);
            var query = service.GetByIdQueryable(parsedKey, context, filter);

            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultUserSettingWithRelationsOwnDto>(entity);
        }

        private static Expression<Func<UserSetting, bool>> CreateUserSettingAccessFilter(IHttpContextAccessor httpContextAccessor)
        {
            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            return FilterExpressionHelper.BuildEqualsExpression<UserSetting, Guid>(x => x.UserId, currentUserId);
        }
    }
}
