using XenoTerra.BussinessLogicLayer.Services.Base.Read;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.RecentChatsDtos;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.RecentChatsServices
{
    public interface IRecentChatsReadService : IReadService<RecentChats, Guid> { }
}
