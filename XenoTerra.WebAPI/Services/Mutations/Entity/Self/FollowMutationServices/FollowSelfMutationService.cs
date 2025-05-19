using AutoMapper;
using XenoTerra.DTOLayer.Dtos.FollowDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.FollowMutationServices
{
    public class FollowSelfMutationService(IMapper mapper)
        : MutationService<Follow, ResultFollowDto, CreateFollowDto, UpdateFollowDto, Guid>(mapper),
        IFollowSelfMutationService
    {
    }
}
