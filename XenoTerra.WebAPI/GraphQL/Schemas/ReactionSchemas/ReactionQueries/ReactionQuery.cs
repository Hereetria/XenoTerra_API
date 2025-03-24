using AutoMapper;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using XenoTerra.BussinessLogicLayer.Services.Entity.ReactionService;
using XenoTerra.DTOLayer.Dtos.ReactionDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.ReactionResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.ReactionResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.ReactionQueryServices;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.ReactionQueries
{
    public class ReactionQuery
    {
        private readonly IMapper _mapper;
        private readonly IQueryResolverHelper<Reaction, Guid> _queryResolver;

        public ReactionQuery(IMapper mapper, IQueryResolverHelper<Reaction, Guid> queryResolver)
        {
            _mapper = mapper;
            _queryResolver = queryResolver;
        }

        [UsePaging]
        [UseFiltering(typeof(ReactionFilterType))]
        [UseSorting(typeof(ReactionSortType))]
        public async Task<IEnumerable<ResultReactionWithRelationsDto>> GetAllReactionsAsync(
            [Service] IReactionQueryService service,
            [Service] IReactionResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entities = await _queryResolver.ResolveEntitiesAsync(query, resolver, context);
            return _mapper.Map<List<ResultReactionWithRelationsDto>>(entities);
        }

        [UsePaging]
        [UseFiltering(typeof(ReactionFilterType))]
        [UseSorting(typeof(ReactionSortType))]
        public async Task<IEnumerable<ResultReactionWithRelationsDto>> GetReactionsByIdsAsync(
            IEnumerable<Guid> keys,
            [Service] IReactionQueryService service,
            [Service] IReactionResolver resolver,
            IResolverContext context)
        {
            var query = service.GetByIdsQueryable(keys, context);
            var entities = await _queryResolver.ResolveEntitiesAsync(query, resolver, context);
            return _mapper.Map<List<ResultReactionWithRelationsDto>>(entities);
        }

        public async Task<ResultReactionWithRelationsDto> GetReactionByIdAsync(
            Guid key,
            [Service] IReactionQueryService service,
            [Service] IReactionResolver resolver,
            IResolverContext context)
        {
            var query = service.GetByIdQueryable(key, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);
            return _mapper.Map<ResultReactionWithRelationsDto>(entity);
        }
    }
}
