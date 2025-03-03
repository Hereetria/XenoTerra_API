
using XenoTerra.EntityLayer.Entities;
using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.BussinessLogicLayer.Services.UserServices;
using XenoTerra.DataAccessLayer.Factories.Abstract;
using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.DataAccessLayer.Services.UserServices;
namespace XenoTerra.BussinessLogicLayer.Services.UserServices
{
     public class UserServiceBLL : GenericRepositoryBLL<User, ResultUserDto, ResultUserByIdDto, CreateUserDto, UpdateUserDto, Guid>, IUserServiceBLL
    {
        private readonly IUserServiceDAL _userServiceDAL;
        public UserServiceBLL(IGenericRepositoryDALFactory repositoryDALFactory, IUserServiceDAL userServiceDAL)
            : base(repositoryDALFactory)
        {
            _userServiceDAL = userServiceDAL;
        }


        public IQueryable<ResultUserDto> GetSuggestedUsers(Guid userId)
        {
            var result = _userServiceDAL.TGetSuggestedUsers(userId);
            return result;
        }
    }
}