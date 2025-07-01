using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.HighlightResolvers;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.HighlightQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using System.Linq.Expressions;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Concrete;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Queries.Paginations.Own;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Queries.Sorts;
using XenoTerra.DTOLayer.Dtos.HighlightDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class HighlightOwnQuery(IMapper mapper, IQueryResolverHelper<Highlight, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<Highlight, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(HighlightOwnFilterType))]
        [UseSorting(typeof(HighlightOwnSortType))]
        public async Task<HighlightOwnConnection> GetAllHighlightsAsync(
            [Service] IHighlightQueryService service,
            [Service] IHighlightResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var filter = BuildAccessFilterAsync(httpContextAccessor);

            var query = service.GetAllQueryable(context, filter);
            var entityOwnConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Highlight, ResultHighlightWithRelationsOwnDto>(
                entityOwnConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<HighlightOwnConnection, ResultHighlightWithRelationsOwnDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(HighlightOwnFilterType))]
        [UseSorting(typeof(HighlightOwnSortType))]
        public async Task<HighlightOwnConnection> GetHighlightsByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IHighlightQueryService service,
            [Service] IHighlightResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var filter = BuildAccessFilterAsync(httpContextAccessor);

            var query = service.GetByIdsQueryable(parsedKeys, context, filter);
            var entityOwnConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Highlight, ResultHighlightWithRelationsOwnDto>(
                entityOwnConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<HighlightOwnConnection, ResultHighlightWithRelationsOwnDto>(connection);
        }

        public async Task<ResultHighlightWithRelationsOwnDto?> GetHighlightByIdAsync(
            string? key,
            [Service] IHighlightQueryService service,
            [Service] IHighlightResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var filter = BuildAccessFilterAsync(httpContextAccessor);

            var query = service.GetByIdQueryable(parsedKey, context, filter);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultHighlightWithRelationsOwnDto>(entity);
        }

        private static Expression<Func<Highlight, bool>> BuildAccessFilterAsync(IHttpContextAccessor httpContextAccessor)
        {
            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            return FilterExpressionHelper.BuildEqualsExpression<Highlight, Guid>(
                b => b.UserId,
                currentUserId
            );
        }
    }
}
