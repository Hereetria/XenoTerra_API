using AutoMapper;
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.DTOLayer.Dtos.ReactionDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.DataLoaders.Base;

namespace XenoTerra.WebAPI.GraphQL.DataLoaders.Entity
{
    public class ReactionDataLoader : EntityDataLoader<Reaction, Guid>
    {
        public ReactionDataLoader(IBatchScheduler batchScheduler, DataLoaderOptions options, AppDbContext dbContext)
            : base(batchScheduler, options, dbContext)
        {
        }
    }


}
