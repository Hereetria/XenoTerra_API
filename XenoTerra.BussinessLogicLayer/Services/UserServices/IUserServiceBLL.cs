
using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.EntityLayer.Entities;
namespace XenoTerra.BussinessLogicLayer.Services.UserServices
{
        public interface IUserServiceBLL : IGenericRepositoryBLL<User, ResultUserDto, ResultUserWithRelationsDto, CreateUserDto, UpdateUserDto, Guid>
    {
        IQueryable<ResultUserDto> GetSuggestedUsers(Guid userId);
    }
}