using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.PostServices;
using XenoTerra.BussinessLogicLayer.Services.UserServices;
using XenoTerra.DataAccessLayer.Services.UserServices;
using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.WebAPI.Schemas.Queries.User
{
    public class UserQuery
    {
        [UseProjection]
        public IQueryable<ResultUserWithRelationsDto> GetUsers(
       List<Guid>? ids,
       [Service] IUserServiceBLL service
   ) => service.GetByIdsQuerableWithRelations(ids ?? service.GetAllIdsAsync().Result);

        [UseProjection]
        [GraphQLDescription("Get all Users")]
        public IQueryable<ResultUserDto> GetAllUsers([Service] IUserServiceBLL userServiceBLL)
        {
            var ids = userServiceBLL.GetAllIdsAsync().Result;
            return userServiceBLL.GetByIdsQuerable(ids);
        }

        //[UseProjection]
        //[GraphQLDescription("Get User by ID")]
        //public IQueryable<ResultUserByIdDto> GetUserById(Guid id, [Service] IUserServiceBLL userServiceBLL)
        //{
        //    var result = userServiceBLL.GetByIdQuerable(id);
        //    if (result == null)
        //    {
        //        throw new Exception($"User with ID {id} not found");
        //    }
        //    return result;
        //}

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [GraphQLDescription("Get Suggested Users")]
        public IQueryable<ResultUserDto> GetSuggestedUsers(
        [Service] IUserServiceBLL userServiceBLL)
        {
            var userId = Guid.Parse("9a466137-3217-424f-39b3-08dd59a25e5a");
            var result = userServiceBLL.GetSuggestedUsers(userId);
            return result;
        }
    }
}
