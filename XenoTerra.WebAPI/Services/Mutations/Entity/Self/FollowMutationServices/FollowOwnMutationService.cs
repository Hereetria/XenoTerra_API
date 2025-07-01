using AutoMapper;
using XenoTerra.DTOLayer.Dtos.FollowDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.FollowMutationServices
{
    public class FollowOwnMutationService(IMapper mapper)
        : MutationService<Follow, ResultFollowOwnDto, CreateFollowOwnDto, UpdateFollowOwnDto, Guid>(mapper),
        IFollowOwnMutationService
    {
    }
}
