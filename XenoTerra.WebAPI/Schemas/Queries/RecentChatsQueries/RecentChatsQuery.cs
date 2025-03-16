using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.BussinessLogicLayer.Services.Entity.RecentChatsService;
using XenoTerra.DTOLayer.Dtos.RecentChatsDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.RecentChatsQueries
{
    public class RecentChatsQuery
    {
        public async Task<IEnumerable<ResultRecentChatsWithRelationsDto>> GetAllRecentChatsAsync(
            [Service] IRecentChatsReadService recentChatsReadService,
            [Service] RecentChatsResolver resolver,
            [Service] IMapper mapper,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = recentChatsReadService.FetchAllQueryable(selectedFields)
                ?? Enumerable.Empty<RecentChats>().AsQueryable();

            var recentChats = await query.ToListAsync();
            await resolver.PopulateRelatedFieldsAsync(recentChats, context);

            return mapper.Map<List<ResultRecentChatsWithRelationsDto>>(recentChats);
        }

        public async Task<IEnumerable<ResultRecentChatsWithRelationsDto>> GetRecentChatsByIdsAsync(
            [Service] IRecentChatsReadService recentChatsReadService,
            [Service] RecentChatsResolver resolver,
            [Service] IMapper mapper,
            List<Guid> keys,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = recentChatsReadService.FetchByIdsQueryable(keys, selectedFields)
                ?? Enumerable.Empty<RecentChats>().AsQueryable();

            var recentChats = await query.ToListAsync();
            await resolver.PopulateRelatedFieldsAsync(recentChats, context);

            return mapper.Map<List<ResultRecentChatsWithRelationsDto>>(recentChats);
        }

        public async Task<ResultRecentChatsWithRelationsDto> GetRecentChatByIdAsync(
            [Service] IRecentChatsReadService recentChatsReadService,
            [Service] RecentChatsResolver resolver,
            [Service] IMapper mapper,
            Guid key,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = recentChatsReadService.FetchByIdQueryable(key, selectedFields)
                ?? Enumerable.Empty<RecentChats>().AsQueryable();

            var recentChat = await query.FirstOrDefaultAsync()
                ?? throw new KeyNotFoundException($"RecentChat with ID {key} was not found in the database.");

            await resolver.PopulateRelatedFieldAsync(recentChat, context);

            return mapper.Map<ResultRecentChatsWithRelationsDto>(recentChat);
        }

    }
}
