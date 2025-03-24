using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.DataLoaders.Base;
using XenoTerra.WebAPI.Schemas.DataLoaders.Base;

namespace XenoTerra.WebAPI.Schemas.DataLoaders.Entity
{
    public class BlockUserDataLoader : EntityDataLoader<BlockUser, Guid>
    {
        public BlockUserDataLoader(IBatchScheduler batchScheduler, DataLoaderOptions options, AppDbContext dbContext) : base(batchScheduler, options, dbContext)
        {
        }
    }

}
