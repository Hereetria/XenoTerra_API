
using XenoTerra.DTOLayer.Dtos.RecentChatsDtos;
using XenoTerra.DataAccessLayer.Repositories;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Services.RecentChatsServices
{
    
    public interface IRecentChatsServiceDAL : IGenericRepositoryDAL<RecentChats, ResultRecentChatsDto, ResultRecentChatsByIdDto ,CreateRecentChatsDto, UpdateRecentChatsDto, Guid>

    {

    }
}