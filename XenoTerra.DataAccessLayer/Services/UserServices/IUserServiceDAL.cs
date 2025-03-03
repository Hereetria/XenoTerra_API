
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.DataAccessLayer.Repositories;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Services.UserServices
{
    
    public interface IUserServiceDAL : IGenericRepositoryDAL<User, ResultUserDto, ResultUserByIdDto ,CreateUserDto, UpdateUserDto, Guid>

    {
        IQueryable<ResultUserDto> TGetSuggestedUsers(Guid userId);
    }
}