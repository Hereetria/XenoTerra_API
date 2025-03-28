using AutoMapper;
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.DTOLayer.Dtos.RoleDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.DataLoaders.Base;

namespace XenoTerra.WebAPI.Schemas.DataLoaders.Entity
{
    public class RoleDataLoader : EntityDataLoader<Role, Guid>
    {
        public RoleDataLoader(IBatchScheduler batchScheduler, DataLoaderOptions options, AppDbContext dbContext)
            : base(batchScheduler, options, dbContext)
        {
        }
    }

}
