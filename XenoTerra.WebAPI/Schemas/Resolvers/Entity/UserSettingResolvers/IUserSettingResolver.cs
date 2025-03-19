using XenoTerra.DTOLayer.Dtos.UserSettingDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers.Base;

namespace XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.UserSettingResolvers
{
    public interface IUserSettingResolver : IEntityResolver<UserSetting, ResultUserSettingWithRelationsDto, Guid>
    {
    }
}
