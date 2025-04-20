using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.StoryResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.StoryQueryServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Queries
{
    public class StoryQuery(IMapper mapper, IQueryResolverHelper<Story, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<Story, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(StoryFilterType))]
        [UseSorting(typeof(StorySortType))]
        public async Task<StoryConnection> GetAllStoriesAsync(
            [Service] IStoryQueryService service,
            [Service] IStoryResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entityConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Story, ResultStoryWithRelationsDto>(
                entityConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<StoryConnection, ResultStoryWithRelationsDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(StoryFilterType))]
        [UseSorting(typeof(StorySortType))]
        public async Task<StoryConnection> GetStoriesByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IStoryQueryService service,
            [Service] IStoryResolver resolver,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entityConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Story, ResultStoryWithRelationsDto>(
                entityConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<StoryConnection, ResultStoryWithRelationsDto>(connection);
        }

        public async Task<ResultStoryWithRelationsDto?> GetStoryByIdAsync(
            string? key,
            [Service] IStoryQueryService service,
            [Service] IStoryResolver resolver,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var query = service.GetByIdQueryable(parsedKey, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return _mapper.Map<ResultStoryWithRelationsDto>(entity);
        }
    }
}
