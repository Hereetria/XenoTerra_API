
using XenoTerra.EntityLayer.Entities;
using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.RecentChatsDtos;
using XenoTerra.BussinessLogicLayer.Services.RecentChatsServices;
using XenoTerra.DataAccessLayer.Factories.Abstract;
namespace XenoTerra.BussinessLogicLayer.Services.RecentChatsServices
{
     public class RecentChatsServiceBLL : GenericRepositoryBLL<RecentChats, ResultRecentChatsDto, CreateRecentChatsDto, UpdateRecentChatsDto, Guid>, IRecentChatsServiceBLL
    {
        public RecentChatsServiceBLL(IGenericRepositoryDALFactory repositoryDALFactory)
            : base(repositoryDALFactory)
        {
        }
    }
}