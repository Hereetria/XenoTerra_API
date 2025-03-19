using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.RecentChatsDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.RecentChatsService
{

    public class RecentChatsReadService : ReadService<RecentChats, ResultRecentChatsWithRelationsDto, Guid>, IRecentChatsReadService
    {
        public RecentChatsReadService(IReadRepository<RecentChats, ResultRecentChatsWithRelationsDto, Guid> repository, IMapper mapper)
            : base(repository) { }
    }
}
