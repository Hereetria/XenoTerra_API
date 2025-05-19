using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.DataLoaders.Base;

namespace XenoTerra.WebAPI.GraphQL.DataLoaders.Entity
{
    public class SearchHistoryUserDataLoader : EntityDataLoader<SearchHistoryUser, Guid>
    {
        public SearchHistoryUserDataLoader(IBatchScheduler batchScheduler, DataLoaderOptions options, AppDbContext dbContext)
            : base(batchScheduler, options, dbContext)
        {
        }
    }
}
