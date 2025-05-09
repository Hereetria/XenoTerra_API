﻿using AutoMapper;
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.DTOLayer.Dtos.LikeDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.DataLoaders.Base;

namespace XenoTerra.WebAPI.Schemas.DataLoaders.Entity
{
    public class LikeDataLoader : EntityDataLoader<Like, Guid>
    {
        public LikeDataLoader(IBatchScheduler batchScheduler, DataLoaderOptions options, AppDbContext dbContext)
            : base(batchScheduler, options, dbContext)
        {
        }
    }


}
