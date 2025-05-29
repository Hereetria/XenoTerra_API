using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.ViewStoryResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.ViewStoryQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using System.Linq.Expressions;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class ViewStorySelfQuery(IMapper mapper, IQueryResolverHelper<ViewStory, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<ViewStory, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(ViewStorySelfFilterType))]
        [UseSorting(typeof(ViewStorySelfSortType))]
        public async Task<ViewStorySelfConnection> GetAllViewStorysAsync(
            [Service] IViewStoryQueryService service,
            [Service] IViewStoryResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var filter = CreateViewStoryAccessFilter(httpContextAccessor);
            var query = service.GetAllQueryable(context, filter);

            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<ViewStory, ResultViewStoryWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<ViewStorySelfConnection, ResultViewStoryWithRelationsDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(ViewStorySelfFilterType))]
        [UseSorting(typeof(ViewStorySelfSortType))]
        public async Task<ViewStorySelfConnection> GetViewStorysByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IViewStoryQueryService service,
            [Service] IViewStoryResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));
            var filter = CreateViewStoryAccessFilter(httpContextAccessor);
            var query = service.GetByIdsQueryable(parsedKeys, context, filter);

            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<ViewStory, ResultViewStoryWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<ViewStorySelfConnection, ResultViewStoryWithRelationsDto>(connection);
        }

        public async Task<ResultViewStoryWithRelationsDto?> GetViewStoryByIdAsync(
            string? key,
            [Service] IViewStoryQueryService service,
            [Service] IViewStoryResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));
            var filter = CreateViewStoryAccessFilter(httpContextAccessor);
            var query = service.GetByIdQueryable(parsedKey, context, filter);

            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultViewStoryWithRelationsDto>(entity);
        }

        private static Expression<Func<ViewStory, bool>> CreateViewStoryAccessFilter(IHttpContextAccessor httpContextAccessor)
        {
            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            return FilterExpressionHelper.BuildEqualsExpression<ViewStory, Guid>(
                view => view.Story.UserId,
                currentUserId
            );
        }
    }
}