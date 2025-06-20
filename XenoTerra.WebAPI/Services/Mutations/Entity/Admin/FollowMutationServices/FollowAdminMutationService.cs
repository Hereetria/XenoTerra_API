using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.DTOLayer.Dtos.FollowAdminDtos.Admin;
namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.FollowMutationServices
{
    public class FollowAdminMutationService(IMapper mapper)
        : MutationService<Follow, ResultFollowAdminDto, CreateFollowAdminDto, UpdateFollowAdminDto, Guid>(mapper),
        IFollowAdminMutationService
    {
    }
}