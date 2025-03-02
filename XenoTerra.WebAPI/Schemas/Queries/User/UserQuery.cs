using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.UserServices;
using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.WebAPI.Schemas.Queries.User
{
    public class UserQuery
    {
        [UseProjection]
        [GraphQLDescription("Get all Users")]
        public IQueryable<ResultUserDto> GetAllUsers([Service] IUserServiceBLL userServiceBLL)
        {
            return userServiceBLL.GetAllQuerable();
        }

        [UseProjection]
        [GraphQLDescription("Get User by ID")]
        public IQueryable<ResultUserByIdDto> GetUserById(Guid id, [Service] IUserServiceBLL userServiceBLL)
        {
            var result = userServiceBLL.GetByIdQuerable(id);
            if (result == null)
            {
                throw new Exception($"User with ID {id} not found");
            }
            return result;
        }
    }
}
