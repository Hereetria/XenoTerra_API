using XenoTerra.BussinessLogicLayer.Services.Entity.UserService;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.UserQueries
{
    public class UserQuery
    {

        public string GetRandomData()
        {
            return "Default data to prevent query class from being empty.";
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

        //[UsePaging(IncludeTotalCount = true)]
        //[UseProjection]
        //[GraphQLDescription("Get Suggested Users")]
        //public IQueryable<ResultUserDto> GetSuggestedUsers(
        //[Service] IUserServiceBLL userServiceBLL)
        //{
        //    var userId = Guid.Parse("9a466137-3217-424f-39b3-08dd59a25e5a");
        //    var result = userServiceBLL.GetSuggestedUsers(userId);
        //    return result;
        //}
    }
}
