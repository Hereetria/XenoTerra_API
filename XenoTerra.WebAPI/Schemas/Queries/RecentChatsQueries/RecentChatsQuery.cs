using AutoMapper;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using XenoTerra.BussinessLogicLayer.Services.Entity.RecentChatsService;
using XenoTerra.DTOLayer.Dtos.RecentChatsDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.RecentChatsResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.RecentChatsQueryServices;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.RecentChatsQueries
{
    public class RecentChatsQuery
    {
        private readonly IMapper _mapper;

        public RecentChatsQuery(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<ResultRecentChatsWithRelationsDto>> GetAllRecentChatsAsync(
            [Service] IRecentChatsQueryService service,
            [Service] IRecentChatsResolver resolver,
            IResolverContext context)
        {
            var recentChats = await service.GetAllAsync(context);
            await resolver.PopulateRelatedFieldsAsync(recentChats, context);
            var recentChatsDtos = _mapper.Map<List<ResultRecentChatsWithRelationsDto>>(recentChats);
            return recentChatsDtos;
        }

        public async Task<IEnumerable<ResultRecentChatsWithRelationsDto>> GetRecentChatsByIdsAsync(
            [Service] IRecentChatsQueryService service,
            [Service] IRecentChatsResolver resolver,
            IEnumerable<Guid> keys,
            IResolverContext context)
        {
            var recentChats = await service.GetByIdsAsync(keys, context);
            await resolver.PopulateRelatedFieldsAsync(recentChats, context);
            var recentChatsDtos = _mapper.Map<List<ResultRecentChatsWithRelationsDto>>(recentChats);
            return recentChatsDtos;
        }

        public async Task<ResultRecentChatsWithRelationsDto> GetRecentChatByIdAsync(
            [Service] IRecentChatsQueryService service,
            [Service] IRecentChatsResolver resolver,
            Guid key,
            IResolverContext context)
        {
            var recentChat = await service.GetByIdAsync(key, context);
            await resolver.PopulateRelatedFieldAsync(recentChat, context);
            var recentChatDto = _mapper.Map<ResultRecentChatsWithRelationsDto>(recentChat);
            return recentChatDto;
        }
    }

}
