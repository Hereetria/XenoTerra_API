using AutoMapper;
using XenoTerra.DTOLayer.Dtos.FollowAdminDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Own.FollowMutationServices
{
    public class FollowOwnMutationService(IMapper mapper)
        : MutationService<Follow, ResultFollowOwnDto, CreateFollowOwnDto, UpdateFollowOwnDto, Guid>(mapper),
        IFollowOwnMutationService
    {
    }
}
