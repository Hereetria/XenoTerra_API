using AutoMapper;
using XenoTerra.DTOLayer.Dtos.FollowDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.FollowMutationServices
{
    public class FollowAdminMutationService(IMapper mapper)
        : MutationService<Follow, ResultFollowDto, CreateFollowDto, UpdateFollowDto, Guid>(mapper),
        IFollowAdminMutationService
    {
    }
}
