using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.StoryHighlightResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.StoryHighlightQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using XenoTerra.DTOLayer.Dtos.StoryHighlightAdminDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class StoryHighlightAdminQuery(IMapper mapper, IQueryResolverHelper<StoryHighlight, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<StoryHighlight, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(StoryHighlightAdminFilterType))]
        [UseSorting(typeof(StoryHighlightAdminSortType))]
        public async Task<StoryHighlightAdminConnection> GetAllStoryHighlightsAsync(
            [Service] IStoryHighlightQueryService service,
            [Service] IStoryHighlightResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<StoryHighlight, ResultStoryHighlightWithRelationsAdminDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<StoryHighlightAdminConnection, ResultStoryHighlightWithRelationsAdminDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(StoryHighlightAdminFilterType))]
        [UseSorting(typeof(StoryHighlightAdminSortType))]
        public async Task<StoryHighlightAdminConnection> GetStoryHighlightsByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IStoryHighlightQueryService service,
            [Service] IStoryHighlightResolver resolver,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<StoryHighlight, ResultStoryHighlightWithRelationsAdminDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<StoryHighlightAdminConnection, ResultStoryHighlightWithRelationsAdminDto>(connection);
        }

        public async Task<ResultStoryHighlightWithRelationsAdminDto?> GetStoryHighlightByIdAsync(
            string? key,
            [Service] IStoryHighlightQueryService service,
            [Service] IStoryHighlightResolver resolver,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var query = service.GetByIdQueryable(parsedKey, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultStoryHighlightWithRelationsAdminDto>(entity);
        }
    }
}
