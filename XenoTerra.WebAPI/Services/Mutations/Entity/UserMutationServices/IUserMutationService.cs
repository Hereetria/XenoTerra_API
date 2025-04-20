using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.UserMutationServices
{
    public interface IUserMutationService : IMutationService<User, ResultUserDto, CreateUserDto, UpdateUserDto, Guid>
    {
    }
}
