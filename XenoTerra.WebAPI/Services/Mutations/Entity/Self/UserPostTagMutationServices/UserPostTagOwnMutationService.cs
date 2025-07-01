using AutoMapper;
using XenoTerra.DTOLayer.Dtos.UserPostTagDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.UserPostTagMutationServices
{
    public class UserPostTagOwnMutationService(IMapper mapper)
        : MutationService<UserPostTag, ResultUserPostTagOwnDto, CreateUserPostTagOwnDto, UpdateUserPostTagOwnDto, Guid>(mapper),
        IUserPostTagOwnMutationService
    {
    }
}
