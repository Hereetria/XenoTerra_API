﻿using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.DataLoaders.Base;

namespace XenoTerra.WebAPI.GraphQL.DataLoaders.Entity
{
    public class StoryHighlightDataLoader : EntityDataLoader<StoryHighlight, Guid>
    {
        public StoryHighlightDataLoader(IBatchScheduler batchScheduler, DataLoaderOptions options, AppDbContext dbContext)
            : base(batchScheduler, options, dbContext)
        {
        }
    }
}
