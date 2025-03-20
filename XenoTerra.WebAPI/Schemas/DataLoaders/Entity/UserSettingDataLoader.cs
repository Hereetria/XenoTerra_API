using AutoMapper;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DTOLayer.Dtos.UserSettingDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.DataLoaders.Base;

namespace XenoTerra.WebAPI.Schemas.DataLoaders.Entity
{
    public class UserSettingDataLoader : EntityDataLoader<UserSetting, ResultUserSettingDto, Guid>
    {
        public UserSettingDataLoader(IBatchScheduler batchScheduler, DataLoaderOptions options, IMapper mapper, AppDbContext dbContext)
            : base(batchScheduler, options, mapper, dbContext)
        {
        }
    }

}
