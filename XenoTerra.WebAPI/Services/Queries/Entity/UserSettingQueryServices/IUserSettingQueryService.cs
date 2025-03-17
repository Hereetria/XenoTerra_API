using XenoTerra.DTOLayer.Dtos.UserSettingDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.UserSettingQueryServices
{
    public interface IUserSettingQueryService : IBaseQueryService<UserSetting, ResultUserSettingDto, Guid> { }

}
