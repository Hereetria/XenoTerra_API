using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.RecentChatsServices;
using XenoTerra.DTOLayer.Dtos.RecentChatsDtos;

namespace XenoTerra.WebAPI.Schemas.Queries.RecentChats
{
    public class RecentChatsQuery
    {
        [UseProjection]
        [GraphQLDescription("Get all RecentChats")]
        public IQueryable<ResultRecentChatsDto> GetAllRecentChats([Service] IRecentChatsServiceBLL recentChatsServiceBLL)
        {
            return recentChatsServiceBLL.GetAllQuerable();
        }

        [UseProjection]
        [GraphQLDescription("Get RecentChat by ID")]
        public IQueryable<ResultRecentChatsByIdDto> GetRecentChatById(Guid id, [Service] IRecentChatsServiceBLL recentChatsServiceBLL)
        {
            var result = recentChatsServiceBLL.GetByIdQuerable(id);
            if (result == null)
            {
                throw new Exception($"RecentChat with ID {id} not found");
            }
            return result;
        }
    }
}
