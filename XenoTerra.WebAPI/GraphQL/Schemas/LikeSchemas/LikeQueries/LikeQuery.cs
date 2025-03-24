using AutoMapper;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using XenoTerra.BussinessLogicLayer.Services.Entity.LikeService;
using XenoTerra.DTOLayer.Dtos.LikeDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.LikeResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.LikeResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.LikeQueryServices;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.LikeQueries
{
    public class LikeQuery
    {
        private readonly IMapper _mapper;
        private readonly IQueryResolverHelper<Like, Guid> _queryResolver;

        public LikeQuery(IMapper mapper, IQueryResolverHelper<Like, Guid> queryResolver)
        {
            _mapper = mapper;
            _queryResolver = queryResolver;
        }

        [UsePaging]
        [UseFiltering(typeof(LikeFilterType))]
        [UseSorting(typeof(LikeSortType))]
        public async Task<IEnumerable<ResultLikeWithRelationsDto>> GetAllLikesAsync(
            [Service] ILikeQueryService service,
            [Service] ILikeResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entities = await _queryResolver.ResolveEntitiesAsync(query, resolver, context);
            return _mapper.Map<List<ResultLikeWithRelationsDto>>(entities);
        }

        [UsePaging]
        [UseFiltering(typeof(LikeFilterType))]
        [UseSorting(typeof(LikeSortType))]
        public async Task<IEnumerable<ResultLikeWithRelationsDto>> GetLikesByIdsAsync(
            IEnumerable<Guid> keys,
            [Service] ILikeQueryService service,
            [Service] ILikeResolver resolver,
            IResolverContext context)
        {
            var query = service.GetByIdsQueryable(keys, context);
            var entities = await _queryResolver.ResolveEntitiesAsync(query, resolver, context);
            return _mapper.Map<List<ResultLikeWithRelationsDto>>(entities);
        }

        public async Task<ResultLikeWithRelationsDto> GetLikeByIdAsync(
            Guid key,
            [Service] ILikeQueryService service,
            [Service] ILikeResolver resolver,
            IResolverContext context)
        {
            var query = service.GetByIdQueryable(key, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);
            return _mapper.Map<ResultLikeWithRelationsDto>(entity);
        }
    }

}
