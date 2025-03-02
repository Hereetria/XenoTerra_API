using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.UserSettingServices;
using XenoTerra.DTOLayer.Dtos.UserSettingDtos;

namespace XenoTerra.WebAPI.Schemas.Queries.UserSetting
{
    public class UserSettingQuery
    {
        [UseProjection]
        [GraphQLDescription("Get all UserSettings")]
        public IQueryable<ResultUserSettingDto> GetAllUserSettings([Service] IUserSettingServiceBLL userSettingServiceBLL)
        {
            return userSettingServiceBLL.GetAllQuerable();
        }

        [UseProjection]
        [GraphQLDescription("Get UserSetting by ID")]
        public IQueryable<ResultUserSettingByIdDto> GetUserSettingById(Guid id, [Service] IUserSettingServiceBLL userSettingServiceBLL)
        {
            var result = userSettingServiceBLL.GetByIdQuerable(id);
            if (result == null)
            {
                throw new Exception($"UserSetting with ID {id} not found");
            }
            return result;
        }
    }
}
