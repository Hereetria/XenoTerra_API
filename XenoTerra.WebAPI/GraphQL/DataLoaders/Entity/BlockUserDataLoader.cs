using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.DataLoaders.Base;

namespace XenoTerra.WebAPI.GraphQL.DataLoaders.Entity
{
    public class BlockUserDataLoader : EntityDataLoader<BlockUser, Guid>
    {
        public BlockUserDataLoader(IBatchScheduler batchScheduler, DataLoaderOptions options, AppDbContext dbContext) : base(batchScheduler, options, dbContext)
        {
        }
    }

}
