using AutoMapper;
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.DTOLayer.Dtos.RecentChatsDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.DataLoaders.Base;

namespace XenoTerra.WebAPI.Schemas.DataLoaders.Entity
{
    public class RecentChatsDataLoader : EntityDataLoader<RecentChats, Guid>
    {
        public RecentChatsDataLoader(IBatchScheduler batchScheduler, DataLoaderOptions options, AppDbContext dbContext)
            : base(batchScheduler, options, dbContext)
        {
        }
    }

}
