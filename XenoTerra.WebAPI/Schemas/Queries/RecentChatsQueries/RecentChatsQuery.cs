using AutoMapper;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using XenoTerra.BussinessLogicLayer.Services.Entity.RecentChatsService;
using XenoTerra.DTOLayer.Dtos.RecentChatsDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Queries._Helpers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.RecentChatsResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.RecentChatsQueryServices;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.RecentChatsQueries
{
    public class RecentChatsQuery
    {
        private readonly IMapper _mapper;
        private readonly IQueryResolverHelper<RecentChat, Guid> _queryResolver;

        public RecentChatsQuery(IMapper mapper, IQueryResolverHelper<RecentChat, Guid> queryResolver)
        {
            _mapper = mapper;
            _queryResolver = queryResolver;
        }

        [UsePaging]
        [UseFiltering(typeof(RecentChatFilterType))]
        [UseSorting(typeof(RecentChatSortType))]
        public async Task<IEnumerable<ResultRecentChatWithRelationsDto>> GetAllRecentChatsAsync(
            [Service] IRecentChatQueryService service,
            [Service] IRecentChatResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entities = await _queryResolver.ResolveEntitiesAsync(query, resolver, context);
            return _mapper.Map<List<ResultRecentChatWithRelationsDto>>(entities);
        }

        [UsePaging]
        [UseFiltering(typeof(RecentChatFilterType))]
        [UseSorting(typeof(RecentChatSortType))]
        public async Task<IEnumerable<ResultRecentChatWithRelationsDto>> GetRecentChatsByIdsAsync(
            IEnumerable<Guid> keys,
            [Service] IRecentChatQueryService service,
            [Service] IRecentChatResolver resolver,
            IResolverContext context)
        {
            var query = service.GetByIdsQueryable(keys, context);
            var entities = await _queryResolver.ResolveEntitiesAsync(query, resolver, context);
            return _mapper.Map<List<ResultRecentChatWithRelationsDto>>(entities);
        }

        public async Task<ResultRecentChatWithRelationsDto> GetRecentChatByIdAsync(
            Guid key,
            [Service] IRecentChatQueryService service,
            [Service] IRecentChatResolver resolver,
            IResolverContext context)
        {
            var query = service.GetByIdQueryable(key, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);
            return _mapper.Map<ResultRecentChatWithRelationsDto>(entity);
        }
    }
}
