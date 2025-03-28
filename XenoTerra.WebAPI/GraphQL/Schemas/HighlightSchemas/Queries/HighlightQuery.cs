using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.HighlightQueries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.HighlightQueries.Sorts;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.HighlightResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.HighlightQueryServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.HighlightQueries
{
    public class HighlightQuery
    {
        private readonly IMapper _mapper;
        private readonly IQueryResolverHelper<Highlight, Guid> _queryResolver;

        public HighlightQuery(IMapper mapper, IQueryResolverHelper<Highlight, Guid> queryResolver)
        {
            _mapper = mapper;
            _queryResolver = queryResolver;
        }

        [UsePaging]
        [UseFiltering(typeof(HighlightFilterType))]
        [UseSorting(typeof(HighlightSortType))]
        public async Task<IEnumerable<ResultHighlightWithRelationsDto>> GetAllHighlightsAsync(
            [Service] IHighlightQueryService service,
            [Service] IHighlightResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entities = await _queryResolver.ResolveEntitiesAsync(query, resolver, context);
            return _mapper.Map<List<ResultHighlightWithRelationsDto>>(entities);
        }

        [UsePaging]
        [UseFiltering(typeof(HighlightFilterType))]
        [UseSorting(typeof(HighlightSortType))]
        public async Task<IEnumerable<ResultHighlightWithRelationsDto>> GetHighlightsByIdsAsync(
            IEnumerable<Guid> keys,
            [Service] IHighlightQueryService service,
            [Service] IHighlightResolver resolver,
            IResolverContext context)
        {
            var query = service.GetByIdsQueryable(keys, context);
            var entities = await _queryResolver.ResolveEntitiesAsync(query, resolver, context);
            return _mapper.Map<List<ResultHighlightWithRelationsDto>>(entities);
        }

        public async Task<ResultHighlightWithRelationsDto> GetHighlightByIdAsync(
            Guid key,
            [Service] IHighlightQueryService service,
            [Service] IHighlightResolver resolver,
            IResolverContext context)
        {
            var query = service.GetByIdQueryable(key, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);
            return _mapper.Map<ResultHighlightWithRelationsDto>(entity);
        }
    }

}
