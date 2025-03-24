using AutoMapper;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using XenoTerra.BussinessLogicLayer.Services.Entity.ViewStoryService;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.ViewStoryResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.ViewStoryResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.ViewStoryQueryServices;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.ViewStoryQueries
{
    public class ViewStoryQuery
    {
        private readonly IMapper _mapper;
        private readonly IQueryResolverHelper<ViewStory, Guid> _queryResolver;

        public ViewStoryQuery(IMapper mapper, IQueryResolverHelper<ViewStory, Guid> queryResolver)
        {
            _mapper = mapper;
            _queryResolver = queryResolver;
        }

        [UsePaging]
        [UseFiltering(typeof(ViewStoryFilterType))]
        [UseSorting(typeof(ViewStorySortType))]
        public async Task<IEnumerable<ResultViewStoryWithRelationsDto>> GetAllViewStoriesAsync(
            [Service] IViewStoryQueryService service,
            [Service] IViewStoryResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entities = await _queryResolver.ResolveEntitiesAsync(query, resolver, context);
            return _mapper.Map<List<ResultViewStoryWithRelationsDto>>(entities);
        }

        [UsePaging]
        [UseFiltering(typeof(ViewStoryFilterType))]
        [UseSorting(typeof(ViewStorySortType))]
        public async Task<IEnumerable<ResultViewStoryWithRelationsDto>> GetViewStoriesByIdsAsync(
            IEnumerable<Guid> keys,
            [Service] IViewStoryQueryService service,
            [Service] IViewStoryResolver resolver,
            IResolverContext context)
        {
            var query = service.GetByIdsQueryable(keys, context);
            var entities = await _queryResolver.ResolveEntitiesAsync(query, resolver, context);
            return _mapper.Map<List<ResultViewStoryWithRelationsDto>>(entities);
        }

        public async Task<ResultViewStoryWithRelationsDto> GetViewStoryByIdAsync(
            Guid key,
            [Service] IViewStoryQueryService service,
            [Service] IViewStoryResolver resolver,
            IResolverContext context)
        {
            var query = service.GetByIdQueryable(key, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);
            return _mapper.Map<ResultViewStoryWithRelationsDto>(entity);
        }
    }
}