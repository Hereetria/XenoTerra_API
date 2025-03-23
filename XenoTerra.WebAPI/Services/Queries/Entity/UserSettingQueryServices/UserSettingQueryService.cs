using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DTOLayer.Dtos.UserSettingDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.UserSettingQueryServices
{
    public class UserSettingQueryService : QueryService<UserSetting, Guid>, IUserSettingQueryService
    {
        public UserSettingQueryService(IReadService<UserSetting, Guid> readService)
            : base(readService)
        {
        }
    }
}
