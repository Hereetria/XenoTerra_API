using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.FollowResolvers;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.FollowQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using System.Linq.Expressions;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Concrete;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Queries.Paginations.Own;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Queries.Sorts;
using XenoTerra.DTOLayer.Dtos.FollowDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class FollowOwnQuery(IMapper mapper, IQueryResolverHelper<Follow, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<Follow, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(FollowOwnFilterType))]
        [UseSorting(typeof(FollowOwnSortType))]
        public async Task<FollowOwnConnection> GetAllFollowsAsync(
            [Service] IFollowQueryService service,
            [Service] IFollowResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var filter = BuildAccessFilterAsync(httpContextAccessor);

            var query = service.GetAllQueryable(context, filter);
            var entityOwnConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Follow, ResultFollowWithRelationsOwnDto>(
                entityOwnConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<FollowOwnConnection, ResultFollowWithRelationsOwnDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(FollowOwnFilterType))]
        [UseSorting(typeof(FollowOwnSortType))]
        public async Task<FollowOwnConnection> GetFollowsByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IFollowQueryService service,
            [Service] IFollowResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var filter = BuildAccessFilterAsync(httpContextAccessor);

            var query = service.GetByIdsQueryable(parsedKeys, context, filter);
            var entityOwnConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Follow, ResultFollowWithRelationsOwnDto>(
                entityOwnConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<FollowOwnConnection, ResultFollowWithRelationsOwnDto>(connection);
        }

        public async Task<ResultFollowWithRelationsOwnDto?> GetFollowByIdAsync(
            string? key,
            [Service] IFollowQueryService service,
            [Service] IFollowResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var filter = BuildAccessFilterAsync(httpContextAccessor);

            var query = service.GetByIdQueryable(parsedKey, context, filter);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultFollowWithRelationsOwnDto>(entity);
        }

        private static Expression<Func<Follow, bool>> BuildAccessFilterAsync(IHttpContextAccessor httpContextAccessor)
        {
            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            return FilterExpressionHelper.BuildEqualsExpression<Follow, Guid>(
                b => b.FollowerId,
                currentUserId
            );
        }
    }
}
