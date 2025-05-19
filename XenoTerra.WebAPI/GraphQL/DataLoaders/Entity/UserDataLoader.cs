using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;
using System.Linq.Expressions;
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.DataLoaders.Base;

namespace XenoTerra.WebAPI.GraphQL.DataLoaders.Entity
{
    public class UserDataLoader : EntityDataLoader<User, Guid>
    {
        public UserDataLoader(IBatchScheduler batchScheduler, DataLoaderOptions options, AppDbContext dbContext)
            : base(batchScheduler, options, dbContext)
        {
        }
    }

}
