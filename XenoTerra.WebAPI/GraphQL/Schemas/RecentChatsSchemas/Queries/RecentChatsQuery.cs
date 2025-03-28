using AutoMapper;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using XenoTerra.BussinessLogicLayer.Services.Entity.RecentChatsService;
using XenoTerra.DTOLayer.Dtos.RecentChatsDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.RecentChatsQueries.Filters;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.RecentChatsResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.RecentChatsQueryServices;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.RecentChatsQueries
{
    public class RecentChatsQuery
    {
        private readonly IMapper _mapper;
        private readonly IQueryResolverHelper<RecentChats, Guid> _queryResolver;

        public RecentChatsQuery(IMapper mapper, IQueryResolverHelper<RecentChats, Guid> queryResolver)
        {
            _mapper = mapper;
            _queryResolver = queryResolver;
        }

        [UsePaging]
        [UseFiltering(typeof(RecentChatsFilterType))]
        [UseSorting(typeof(RecentChatsSortType))]
        public async Task<IEnumerable<ResultRecentChatsWithRelationsDto>> GetAllRecentChatsAsync(
            [Service] IRecentChatsQueryService service,
            [Service] IRecentChatsResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entities = await _queryResolver.ResolveEntitiesAsync(query, resolver, context);
            return _mapper.Map<List<ResultRecentChatsWithRelationsDto>>(entities);
        }

        [UsePaging]
        [UseFiltering(typeof(RecentChatsFilterType))]
        [UseSorting(typeof(RecentChatsSortType))]
        public async Task<IEnumerable<ResultRecentChatsWithRelationsDto>> GetRecentChatsByIdsAsync(
            IEnumerable<Guid> keys,
            [Service] IRecentChatsQueryService service,
            [Service] IRecentChatsResolver resolver,
            IResolverContext context)
        {
            var query = service.GetByIdsQueryable(keys, context);
            var entities = await _queryResolver.ResolveEntitiesAsync(query, resolver, context);
            return _mapper.Map<List<ResultRecentChatsWithRelationsDto>>(entities);
        }

        public async Task<ResultRecentChatsWithRelationsDto> GetRecentChatByIdAsync(
            Guid key,
            [Service] IRecentChatsQueryService service,
            [Service] IRecentChatsResolver resolver,
            IResolverContext context)
        {
            var query = service.GetByIdQueryable(key, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);
            return _mapper.Map<ResultRecentChatsWithRelationsDto>(entity);
        }
    }
}
