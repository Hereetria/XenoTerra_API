using XenoTerra.BussinessLogicLayer.Services.Entity.UserSettingService;
using XenoTerra.DTOLayer.Dtos.UserSettingDtos;

namespace XenoTerra.WebAPI.Schemas.Mutations.UserSettingMutations
{
    public class UserSettingMutation
    {
        [UseProjection]
        [GraphQLDescription("Create a new UserSetting")]
        public async Task<ResultUserSettingDto> CreateUserSettingAsync(CreateUserSettingDto createUserSettingDto, [Service] IUserSettingWriteService userSettingWriteService)
        {
            var result = await userSettingWriteService.CreateAsync(createUserSettingDto);
            return result;
        }

        [UseProjection]
        [GraphQLDescription("Update an existing UserSetting")]
        public async Task<ResultUserSettingDto> UpdateUserSettingAsync(UpdateUserSettingDto updateUserSettingDto, [Service] IUserSettingWriteService userSettingWriteService)
        {
            var result = await userSettingWriteService.UpdateAsync(updateUserSettingDto);
            return result;
        }

        [GraphQLDescription("Delete a UserSetting by ID")]
        public async Task<bool> DeleteUserSettingAsync(Guid id, [Service] IUserSettingWriteService userSettingWriteService)
        {
            var result = await userSettingWriteService.DeleteAsync(id);
            return result;
        }
    }
}
