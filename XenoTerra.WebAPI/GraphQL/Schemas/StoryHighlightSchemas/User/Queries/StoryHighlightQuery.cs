using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.StoryHighlightDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.StoryHighlightResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers;
using XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.StoryHighlightQueryServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Queries
{
    public class StoryHighlightQuery(IMapper mapper, IQueryResolverHelper<StoryHighlight, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<StoryHighlight, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(StoryHighlightFilterType))]
        [UseSorting(typeof(StoryHighlightSortType))]
        public async Task<StoryHighlightConnection> GetAllStoryHighlightsAsync(
            [Service] IStoryHighlightQueryService service,
            [Service] IStoryHighlightResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entityConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<StoryHighlight, ResultStoryHighlightWithRelationsDto>(
                entityConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<StoryHighlightConnection, ResultStoryHighlightWithRelationsDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(StoryHighlightFilterType))]
        [UseSorting(typeof(StoryHighlightSortType))]
        public async Task<StoryHighlightConnection> GetStoryHighlightsByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IStoryHighlightQueryService service,
            [Service] IStoryHighlightResolver resolver,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entityConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<StoryHighlight, ResultStoryHighlightWithRelationsDto>(
                entityConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<StoryHighlightConnection, ResultStoryHighlightWithRelationsDto>(connection);
        }

        public async Task<ResultStoryHighlightWithRelationsDto?> GetStoryHighlightByIdAsync(
            string? key,
            [Service] IStoryHighlightQueryService service,
            [Service] IStoryHighlightResolver resolver,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var query = service.GetByIdQueryable(parsedKey, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return _mapper.Map<ResultStoryHighlightWithRelationsDto>(entity);
        }
    }
}
