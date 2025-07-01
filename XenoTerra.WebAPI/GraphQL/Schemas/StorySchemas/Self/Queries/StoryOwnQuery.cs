using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.StoryResolvers;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.StoryQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using System.Linq.Expressions;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Concrete;
using Microsoft.EntityFrameworkCore;
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Queries.Paginations.Own;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Queries.Sorts;
using XenoTerra.DTOLayer.Dtos.StoryDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class StoryOwnQuery(IMapper mapper, IQueryResolverHelper<Story, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<Story, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(StoryOwnFilterType))]
        [UseSorting(typeof(StoryOwnSortType))]
        public async Task<StoryOwnConnection> GetAllStoriesAsync(
            [Service] IStoryQueryService service,
            [Service] IStoryResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var filter = BuildAccessFilterAsync(httpContextAccessor);

            var query = service.GetAllQueryable(context, filter);
            var entityOwnConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Story, ResultStoryWithRelationsOwnDto>(
                entityOwnConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<StoryOwnConnection, ResultStoryWithRelationsOwnDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(StoryOwnFilterType))]
        [UseSorting(typeof(StoryOwnSortType))]
        public async Task<StoryOwnConnection> GetStoriesByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IStoryQueryService service,
            [Service] IStoryResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));
            var filter = BuildAccessFilterAsync(httpContextAccessor);

            var query = service.GetByIdsQueryable(parsedKeys, context, filter);
            var entityOwnConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Story, ResultStoryWithRelationsOwnDto>(
                entityOwnConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<StoryOwnConnection, ResultStoryWithRelationsOwnDto>(connection);
        }

        public async Task<ResultStoryWithRelationsOwnDto?> GetStoryByIdAsync(
            string? key,
            [Service] IStoryQueryService service,
            [Service] IStoryResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));
            var filter = BuildAccessFilterAsync(httpContextAccessor);

            var query = service.GetByIdQueryable(parsedKey, context, filter);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultStoryWithRelationsOwnDto>(entity);
        }

        private static Expression<Func<Story, bool>> BuildAccessFilterAsync(IHttpContextAccessor httpContextAccessor)
        {
            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            return FilterExpressionHelper.BuildEqualsExpression<Story, Guid>(
                b => b.UserId,
                currentUserId
            );
        }
    }
}
