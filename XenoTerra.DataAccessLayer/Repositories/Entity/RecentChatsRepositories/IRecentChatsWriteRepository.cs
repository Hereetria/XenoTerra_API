using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.RecentChatsRepository
{
    public interface IRecentChatsWriteRepository : IWriteRepository<RecentChats, Guid>
    {
    }

}
