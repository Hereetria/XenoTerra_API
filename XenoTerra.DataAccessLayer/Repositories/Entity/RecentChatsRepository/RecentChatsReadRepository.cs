using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.RecentChatsRepository
{
    public class RecentChatsReadRepository : ReadRepository<RecentChats, Guid>, IRecentChatsReadRepository
    {
        public RecentChatsReadRepository(AppDbContext context) : base(context) { }
    }

}
