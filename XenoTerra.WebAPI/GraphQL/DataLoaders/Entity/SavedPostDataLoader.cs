using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.DataLoaders.Base;

namespace XenoTerra.WebAPI.GraphQL.DataLoaders.Entity
{
    public class SavedPostDataLoader : EntityDataLoader<SavedPost, Guid>
    {
        public SavedPostDataLoader(IBatchScheduler batchScheduler, DataLoaderOptions options, AppDbContext dbContext)
            : base(batchScheduler, options, dbContext)
        {
        }
    }

}
