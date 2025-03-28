using AutoMapper;
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.DTOLayer.Dtos.NotificationDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.DataLoaders.Base;

namespace XenoTerra.WebAPI.Schemas.DataLoaders.Entity
{
    public class NotificationDataLoader : EntityDataLoader<Notification, Guid>
    {
        public NotificationDataLoader(IBatchScheduler batchScheduler, DataLoaderOptions options, AppDbContext dbContext)
            : base(batchScheduler, options, dbContext)
        {
        }
    }


}
