
using XenoTerra.EntityLayer.Entities;
using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.BussinessLogicLayer.Services.UserServices;
using XenoTerra.DataAccessLayer.Factories.Abstract;
namespace XenoTerra.BussinessLogicLayer.Services.UserServices
{
     public class UserServiceBLL : GenericRepositoryBLL<User, ResultUserDto, ResultUserByIdDto, CreateUserDto, UpdateUserDto, Guid>, IUserServiceBLL
    {
        public UserServiceBLL(IGenericRepositoryDALFactory repositoryDALFactory)
            : base(repositoryDALFactory)
        {
        }
    }
}