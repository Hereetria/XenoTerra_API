using AutoMapper;
using HotChocolate;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using XenoTerra.BussinessLogicLayer.Services.Entity.FollowService;
using XenoTerra.DTOLayer.Dtos.FollowDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Queries._Helpers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.FollowResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.FollowQueryServices;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.FollowQueries
{
    public class FollowQuery
    {
        private readonly IMapper _mapper;
        private readonly IQueryResolverHelper<Follow, Guid> _queryResolver;

        public FollowQuery(IMapper mapper, IQueryResolverHelper<Follow, Guid> queryResolver)
        {
            _mapper = mapper;
            _queryResolver = queryResolver;
        }

        [UsePaging]
        [UseFiltering(typeof(FollowFilterType))]
        [UseSorting(typeof(FollowSortType))]
        public async Task<IEnumerable<ResultFollowWithRelationsDto>> GetAllFollowsAsync(
            [Service] IFollowQueryService service,
            [Service] IFollowResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entities = await _queryResolver.ResolveEntitiesAsync(query, resolver, context);
            return _mapper.Map<List<ResultFollowWithRelationsDto>>(entities);
        }

        [UsePaging]
        [UseFiltering(typeof(FollowFilterType))]
        [UseSorting(typeof(FollowSortType))]
        public async Task<IEnumerable<ResultFollowWithRelationsDto>> GetFollowsByIdsAsync(
            IEnumerable<Guid> keys,
            [Service] IFollowQueryService service,
            [Service] IFollowResolver resolver,
            IResolverContext context)
        {
            var query = service.GetByIdsQueryable(keys, context);
            var entities = await _queryResolver.ResolveEntitiesAsync(query, resolver, context);
            return _mapper.Map<List<ResultFollowWithRelationsDto>>(entities);
        }

        public async Task<ResultFollowWithRelationsDto> GetFollowByIdAsync(
            Guid key,
            [Service] IFollowQueryService service,
            [Service] IFollowResolver resolver,
            IResolverContext context)
        {
            var query = service.GetByIdQueryable(key, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);
            return _mapper.Map<ResultFollowWithRelationsDto>(entity);
        }
    }

}
