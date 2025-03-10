using XenoTerra.BussinessLogicLayer.Services.Entity.UserService;
using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.WebAPI.Schemas.Mutations.User
{
    public class UserMutation
    {
        [UseProjection]
        [GraphQLDescription("Create a new User")]
        public async Task<ResultUserDto> CreateUserAsync(CreateUserDto createUserDto, [Service] IUserWriteService userWriteService)
        {
            var result = await userWriteService.CreateAsync(createUserDto);
            return result;
        }

        [UseProjection]
        [GraphQLDescription("Update an existing User")]
        public async Task<ResultUserDto> UpdateUserAsync(UpdateUserDto updateUserDto, [Service] IUserWriteService userWriteService)
        {
            var result = await userWriteService.UpdateAsync(updateUserDto);
            return result;
        }

        [GraphQLDescription("Delete a User by ID")]
        public async Task<bool> DeleteUserAsync(Guid id, [Service] IUserWriteService userWriteService)
        {
            var result = await userWriteService.DeleteAsync(id);
            return result;
        }
    }
}
