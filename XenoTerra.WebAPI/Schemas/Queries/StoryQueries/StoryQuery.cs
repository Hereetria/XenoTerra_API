using AutoMapper;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using XenoTerra.BussinessLogicLayer.Services.Entity.StoryService;
using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Queries._Helpers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.StoryResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.StoryQueryServices;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.StoryQueries
{
    public class StoryQuery
    {
        private readonly IMapper _mapper;
        private readonly IQueryResolverHelper<Story, Guid> _queryResolver;

        public StoryQuery(IMapper mapper, IQueryResolverHelper<Story, Guid> queryResolver)
        {
            _mapper = mapper;
            _queryResolver = queryResolver;
        }

        [UsePaging]
        [UseFiltering(typeof(StoryFilterType))]
        [UseSorting(typeof(StorySortType))]
        public async Task<IEnumerable<ResultStoryWithRelationsDto>> GetAllStoriesAsync(
            [Service] IStoryQueryService service,
            [Service] IStoryResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entities = await _queryResolver.ResolveEntitiesAsync(query, resolver, context);
            return _mapper.Map<List<ResultStoryWithRelationsDto>>(entities);
        }

        [UsePaging]
        [UseFiltering(typeof(StoryFilterType))]
        [UseSorting(typeof(StorySortType))]
        public async Task<IEnumerable<ResultStoryWithRelationsDto>> GetStoriesByIdsAsync(
            IEnumerable<Guid> keys,
            [Service] IStoryQueryService service,
            [Service] IStoryResolver resolver,
            IResolverContext context)
        {
            var query = service.GetByIdsQueryable(keys, context);
            var entities = await _queryResolver.ResolveEntitiesAsync(query, resolver, context);
            return _mapper.Map<List<ResultStoryWithRelationsDto>>(entities);
        }

        public async Task<ResultStoryWithRelationsDto> GetStoryByIdAsync(
            Guid key,
            [Service] IStoryQueryService service,
            [Service] IStoryResolver resolver,
            IResolverContext context)
        {
            var query = service.GetByIdQueryable(key, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);
            return _mapper.Map<ResultStoryWithRelationsDto>(entity);
        }
    }
}
