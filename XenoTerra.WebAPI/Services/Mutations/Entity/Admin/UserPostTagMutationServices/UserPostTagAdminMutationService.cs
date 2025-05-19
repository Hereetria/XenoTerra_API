using AutoMapper;
using XenoTerra.DTOLayer.Dtos.UserPostTagDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.UserPostTagMutationServices
{
    public class UserPostTagAdminMutationService(IMapper mapper)
        : MutationService<UserPostTag, ResultUserPostTagDto, CreateUserPostTagDto, UpdateUserPostTagDto, Guid>(mapper),
        IUserPostTagAdminMutationService
    {
    }
}
