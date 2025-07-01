using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.UserPostTagResolvers;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.UserPostTagQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using System.Linq.Expressions;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Concrete;
using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Self.Queries.Paginations.Own;
using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Self.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Self.Queries.Sorts;
using XenoTerra.DTOLayer.Dtos.UserPostTagDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Self.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class UserPostTagOwnQuery(IMapper mapper, IQueryResolverHelper<UserPostTag, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<UserPostTag, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(UserPostTagOwnFilterType))]
        [UseSorting(typeof(UserPostTagOwnSortType))]
        public async Task<UserPostTagOwnConnection> GetAllUserPostTagsAsync(
            [Service] IUserPostTagQueryService service,
            [Service] IUserPostTagResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var filter = BuildAccessFilterAsync(httpContextAccessor);

            var query = service.GetAllQueryable(context, filter);
            var entityOwnConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<UserPostTag, ResultUserPostTagWithRelationsOwnDto>(
                entityOwnConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<UserPostTagOwnConnection, ResultUserPostTagWithRelationsOwnDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(UserPostTagOwnFilterType))]
        [UseSorting(typeof(UserPostTagOwnSortType))]
        public async Task<UserPostTagOwnConnection> GetUserPostTagsByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IUserPostTagQueryService service,
            [Service] IUserPostTagResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var filter = BuildAccessFilterAsync(httpContextAccessor);

            var query = service.GetByIdsQueryable(parsedKeys, context, filter);
            var entityOwnConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<UserPostTag, ResultUserPostTagWithRelationsOwnDto>(
                entityOwnConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<UserPostTagOwnConnection, ResultUserPostTagWithRelationsOwnDto>(connection);
        }

        public async Task<ResultUserPostTagWithRelationsOwnDto?> GetUserPostTagByIdAsync(
            string? key,
            [Service] IUserPostTagQueryService service,
            [Service] IUserPostTagResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var filter = BuildAccessFilterAsync(httpContextAccessor);

            var query = service.GetByIdQueryable(parsedKey, context, filter);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultUserPostTagWithRelationsOwnDto>(entity);
        }

        private static Expression<Func<UserPostTag, bool>> BuildAccessFilterAsync(IHttpContextAccessor httpContextAccessor)
        {
            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            return FilterExpressionHelper.BuildEqualsExpression<UserPostTag, Guid>(
                b => b.UserId,
                currentUserId
            );
        }
    }
}
