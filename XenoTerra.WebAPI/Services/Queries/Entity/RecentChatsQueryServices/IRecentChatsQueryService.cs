using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.RecentChatsQueryServices
{
    public interface IRecentChatsQueryService : IQueryService<RecentChats, Guid>
    {
    }
}
