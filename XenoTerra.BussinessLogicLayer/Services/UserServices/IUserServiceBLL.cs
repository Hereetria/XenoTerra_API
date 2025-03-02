
using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.EntityLayer.Entities;
namespace XenoTerra.BussinessLogicLayer.Services.UserServices
{
        public interface IUserServiceBLL : IGenericRepositoryBLL<User, ResultUserDto, ResultUserByIdDto, CreateUserDto, UpdateUserDto, Guid>
    {

    }
}