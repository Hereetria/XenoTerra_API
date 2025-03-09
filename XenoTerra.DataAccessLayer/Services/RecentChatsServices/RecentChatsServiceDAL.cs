

using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DTOLayer.Dtos.RecentChatsDtos;
using XenoTerra.DataAccessLayer.Repositories;

namespace XenoTerra.DataAccessLayer.Services.RecentChatsServices
{
    
    public class RecentChatsServiceDAL : GenericRepositoryDAL<RecentChats, ResultRecentChatsDto, ResultRecentChatsWithRelationsDto, CreateRecentChatsDto, UpdateRecentChatsDto, Guid>, IRecentChatsServiceDAL

    {

        public RecentChatsServiceDAL(AppDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

    }
}