using AutoMapper;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DTOLayer.Dtos.MessageDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.DataLoaders.Base;

namespace XenoTerra.WebAPI.Schemas.DataLoaders.Entity
{
    public class MessageDataLoader : EntityDataLoader<Message, ResultMessageDto, Guid>
    {
        public MessageDataLoader(IBatchScheduler batchScheduler, DataLoaderOptions options, IMapper mapper, AppDbContext dbContext)
            : base(batchScheduler, options, mapper, dbContext)
        {
        }
    }


}
