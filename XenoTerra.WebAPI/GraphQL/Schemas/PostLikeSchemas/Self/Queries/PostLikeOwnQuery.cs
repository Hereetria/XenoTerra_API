using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using System.Linq.Expressions;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Concrete;
using XenoTerra.WebAPI.Services.Queries.Entity.PostLikeQueryServices;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.PostLikeResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Queries.Paginations.Own;
using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Queries.Sorts;
using XenoTerra.DTOLayer.Dtos.PostLikeDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class PostLikeOwnQuery(IMapper mapper, IQueryResolverHelper<PostLike, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<PostLike, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(PostLikeOwnFilterType))]
        [UseSorting(typeof(PostLikeOwnSortType))]
        public async Task<PostLikeOwnConnection> GetAllPostLikesAsync(
            [Service] IPostLikeQueryService service,
            [Service] IPostLikeResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var filter = BuildAccessFilterAsync(httpContextAccessor);

            var query = service.GetAllQueryable(context, filter);
            var entityOwnConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<PostLike, ResultPostLikeWithRelationsOwnDto>(
                entityOwnConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<PostLikeOwnConnection, ResultPostLikeWithRelationsOwnDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(PostLikeOwnFilterType))]
        [UseSorting(typeof(PostLikeOwnSortType))]
        public async Task<PostLikeOwnConnection> GetPostLikesByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IPostLikeQueryService service,
            [Service] IPostLikeResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var filter = BuildAccessFilterAsync(httpContextAccessor);

            var query = service.GetByIdsQueryable(parsedKeys, context, filter);
            var entityOwnConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<PostLike, ResultPostLikeWithRelationsOwnDto>(
                entityOwnConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<PostLikeOwnConnection, ResultPostLikeWithRelationsOwnDto>(connection);
        }

        public async Task<ResultPostLikeWithRelationsOwnDto?> GetPostLikeByIdAsync(
            string? key,
            [Service] IPostLikeQueryService service,
            [Service] IPostLikeResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var filter = BuildAccessFilterAsync(httpContextAccessor);

            var query = service.GetByIdQueryable(parsedKey, context, filter);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultPostLikeWithRelationsOwnDto>(entity);
        }

        private static Expression<Func<PostLike, bool>> BuildAccessFilterAsync(IHttpContextAccessor httpContextAccessor)
        {
            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            return FilterExpressionHelper.BuildEqualsExpression<PostLike, Guid>(
                b => b.UserId,
                currentUserId
            );
        }
    }
}
