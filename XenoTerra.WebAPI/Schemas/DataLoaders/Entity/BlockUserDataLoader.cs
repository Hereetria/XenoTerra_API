using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.DataLoaders.Base;

namespace XenoTerra.WebAPI.Schemas.DataLoaders.Entity
{
    public class BlockUserDataLoader : EntityDataLoader<BlockUser, ResultBlockUserDto, Guid>
    {
        public BlockUserDataLoader(IBatchScheduler batchScheduler, DataLoaderOptions options, IMapper mapper, AppDbContext dbContext) : base(batchScheduler, options, mapper, dbContext)
        {
        }
    }

}
