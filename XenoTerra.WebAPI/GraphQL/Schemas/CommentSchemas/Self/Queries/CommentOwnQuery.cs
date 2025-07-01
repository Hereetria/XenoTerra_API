using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.CommentResolvers;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.CommentQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using System.Linq.Expressions;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Concrete;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Queries.Paginations.Own;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Queries.Sorts;
using XenoTerra.DTOLayer.Dtos.CommentDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class CommentOwnQuery(IMapper mapper, IQueryResolverHelper<Comment, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<Comment, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(CommentOwnFilterType))]
        [UseSorting(typeof(CommentOwnSortType))]
        public async Task<CommentOwnConnection> GetAllCommentsAsync(
            [Service] ICommentQueryService service,
            [Service] ICommentResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var filter = BuildAccessFilterAsync(httpContextAccessor);

            var query = service.GetAllQueryable(context, filter);
            var entityOwnConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Comment, ResultCommentWithRelationsOwnDto>(
                entityOwnConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<CommentOwnConnection, ResultCommentWithRelationsOwnDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(CommentOwnFilterType))]
        [UseSorting(typeof(CommentOwnSortType))]
        public async Task<CommentOwnConnection> GetCommentsByIdsAsync(
            IEnumerable<string>? keys,
            [Service] ICommentQueryService service,
            [Service] ICommentResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var filter = BuildAccessFilterAsync(httpContextAccessor);

            var query = service.GetByIdsQueryable(parsedKeys, context, filter);
            var entityOwnConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Comment, ResultCommentWithRelationsOwnDto>(
                entityOwnConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<CommentOwnConnection, ResultCommentWithRelationsOwnDto>(connection);
        }

        public async Task<ResultCommentWithRelationsOwnDto?> GetCommentByIdAsync(
            string? key,
            [Service] ICommentQueryService service,
            [Service] ICommentResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var filter = BuildAccessFilterAsync(httpContextAccessor);

            var query = service.GetByIdQueryable(parsedKey, context, filter);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultCommentWithRelationsOwnDto>(entity);
        }

        private static Expression<Func<Comment, bool>> BuildAccessFilterAsync(IHttpContextAccessor httpContextAccessor)
        {
            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            return FilterExpressionHelper.BuildEqualsExpression<Comment, Guid>(
                b => b.UserId,
                currentUserId
            );
        }
    }
}
