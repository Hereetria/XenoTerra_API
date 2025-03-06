
using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.RecentChatsDtos;
using XenoTerra.EntityLayer.Entities;
namespace XenoTerra.BussinessLogicLayer.Services.RecentChatsServices
{
        public interface IRecentChatsServiceBLL : IGenericRepositoryBLL<RecentChats, ResultRecentChatsDto, CreateRecentChatsDto, UpdateRecentChatsDto, Guid>
    {

    }
}