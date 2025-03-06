using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.RecentChatsServices;
using XenoTerra.DTOLayer.Dtos.RecentChatsDtos;

namespace XenoTerra.WebAPI.Schemas.Mutations.RecentChats
{
    public class RecentChatsMutation
    {
        [UseProjection]
        [GraphQLDescription("Create a new RecentChat")]
        public async Task<ResultRecentChatsDto> CreateRecentChatAsync(CreateRecentChatsDto createRecentChatsDto, [Service] IRecentChatsServiceBLL recentChatsServiceBLL)
        {
            var result = await recentChatsServiceBLL.CreateAsync(createRecentChatsDto);
            return result;
        }

        [UseProjection]
        [GraphQLDescription("Update an existing RecentChat")]
        public async Task<ResultRecentChatsDto> UpdateRecentChatAsync(UpdateRecentChatsDto updateRecentChatsDto, [Service] IRecentChatsServiceBLL recentChatsServiceBLL)
        {
            var result = await recentChatsServiceBLL.UpdateAsync(updateRecentChatsDto);
            return result;
        }

        [GraphQLDescription("Delete a RecentChat by ID")]
        public async Task<bool> DeleteRecentChatAsync(Guid id, [Service] IRecentChatsServiceBLL recentChatsServiceBLL)
        {
            var result = await recentChatsServiceBLL.DeleteAsync(id);
            return result;
        }
    }
}
