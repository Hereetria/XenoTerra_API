using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.UserServices;
using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.WebAPI.Schemas.Mutations.User
{
    public class UserMutation
    {
        [UseProjection]
        [GraphQLDescription("Create a new User")]
        public async Task<ResultUserByIdDto> CreateUserAsync(CreateUserDto createUserDto, [Service] IUserServiceBLL userServiceBLL)
        {
            var result = await userServiceBLL.CreateAsync(createUserDto);
            return result;
        }

        [UseProjection]
        [GraphQLDescription("Update an existing User")]
        public async Task<ResultUserByIdDto> UpdateUserAsync(UpdateUserDto updateUserDto, [Service] IUserServiceBLL userServiceBLL)
        {
            var result = await userServiceBLL.UpdateAsync(updateUserDto);
            return result;
        }

        [GraphQLDescription("Delete a User by ID")]
        public async Task<bool> DeleteUserAsync(Guid id, [Service] IUserServiceBLL userServiceBLL)
        {
            var result = await userServiceBLL.DeleteAsync(id);
            return result;
        }
    }
}
