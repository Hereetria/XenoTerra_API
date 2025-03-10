using XenoTerra.BussinessLogicLayer.Services.Entity.RecentChatsService;
using XenoTerra.DTOLayer.Dtos.RecentChatsDtos;

namespace XenoTerra.WebAPI.Schemas.Mutations.RecentChats
{
    public class RecentChatsMutation
    {
        [UseProjection]
        [GraphQLDescription("Create a new RecentChat")]
        public async Task<ResultRecentChatsDto> CreateRecentChatAsync(CreateRecentChatsDto createRecentChatsDto, [Service] IRecentChatsWriteService recentChatsWriteService)
        {
            var result = await recentChatsWriteService.CreateAsync(createRecentChatsDto);
            return result;
        }

        [UseProjection]
        [GraphQLDescription("Update an existing RecentChat")]
        public async Task<ResultRecentChatsDto> UpdateRecentChatAsync(UpdateRecentChatsDto updateRecentChatsDto, [Service] IRecentChatsWriteService recentChatsWriteService)
        {
            var result = await recentChatsWriteService.UpdateAsync(updateRecentChatsDto);
            return result;
        }

        [GraphQLDescription("Delete a RecentChat by ID")]
        public async Task<bool> DeleteRecentChatAsync(Guid id, [Service] IRecentChatsWriteService recentChatsWriteService)
        {
            var result = await recentChatsWriteService.DeleteAsync(id);
            return result;
        }
    }
}
