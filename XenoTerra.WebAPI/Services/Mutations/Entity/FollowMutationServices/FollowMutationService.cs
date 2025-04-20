using AutoMapper;
using XenoTerra.DTOLayer.Dtos.FollowDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.FollowMutationServices
{
    public class FollowMutationService(IMapper mapper)
        : MutationService<Follow, ResultFollowDto, CreateFollowDto, UpdateFollowDto, Guid>(mapper),
        IFollowMutationService
    {
    }
}
