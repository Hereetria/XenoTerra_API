using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;
using System.Linq.Expressions;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.DataLoaders.Base;

namespace XenoTerra.WebAPI.Schemas.DataLoaders.Entity
{
    public class UserDataLoader : EntityDataLoader<User, ResultUserDto, Guid>
    {
        public UserDataLoader(IBatchScheduler batchScheduler, DataLoaderOptions options, IMapper mapper, AppDbContext dbContext)
            : base(batchScheduler, options, mapper, dbContext)
        {
        }
    }

}
