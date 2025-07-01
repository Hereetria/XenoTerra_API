using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.DTOLayer.Dtos.UserPostTagDtos.Admin;
namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.UserPostTagMutationServices
{
    public class UserPostTagAdminMutationService(IMapper mapper)
        : MutationService<UserPostTag, ResultUserPostTagAdminDto, CreateUserPostTagAdminDto, UpdateUserPostTagAdminDto, Guid>(mapper),
        IUserPostTagAdminMutationService
    {
    }
}