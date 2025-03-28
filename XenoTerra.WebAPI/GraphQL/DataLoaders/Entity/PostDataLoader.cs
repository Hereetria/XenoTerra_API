using AutoMapper;
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.DataLoaders.Base;

namespace XenoTerra.WebAPI.Schemas.DataLoaders.Entity
{
    public class PostDataLoader : EntityDataLoader<Post, Guid>
    {
        public PostDataLoader(IBatchScheduler batchScheduler, DataLoaderOptions options, AppDbContext dbContext)
            : base(batchScheduler, options, dbContext)
        {
        }
    }


}
