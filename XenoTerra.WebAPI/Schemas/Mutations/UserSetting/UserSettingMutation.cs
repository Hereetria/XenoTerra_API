using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.UserSettingServices;
using XenoTerra.DTOLayer.Dtos.UserSettingDtos;

namespace XenoTerra.WebAPI.Schemas.Mutations.UserSetting
{
    public class UserSettingMutation
    {
        [UseProjection]
        [GraphQLDescription("Create a new UserSetting")]
        public async Task<ResultUserSettingByIdDto> CreateUserSettingAsync(CreateUserSettingDto createUserSettingDto, [Service] IUserSettingServiceBLL userSettingServiceBLL)
        {
            var result = await userSettingServiceBLL.CreateAsync(createUserSettingDto);
            return result;
        }

        [UseProjection]
        [GraphQLDescription("Update an existing UserSetting")]
        public async Task<ResultUserSettingByIdDto> UpdateUserSettingAsync(UpdateUserSettingDto updateUserSettingDto, [Service] IUserSettingServiceBLL userSettingServiceBLL)
        {
            var result = await userSettingServiceBLL.UpdateAsync(updateUserSettingDto);
            return result;
        }

        [GraphQLDescription("Delete a UserSetting by ID")]
        public async Task<bool> DeleteUserSettingAsync(Guid id, [Service] IUserSettingServiceBLL userSettingServiceBLL)
        {
            var result = await userSettingServiceBLL.DeleteAsync(id);
            return result;
        }
    }
}
