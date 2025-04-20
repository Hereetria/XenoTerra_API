using AutoMapper;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.UserMutationServices
{
    public class UserMutationService(IMapper mapper)
        : MutationService<User, ResultUserDto, CreateUserDto, UpdateUserDto, Guid>(mapper),
        IUserMutationService
    {
    }
}
