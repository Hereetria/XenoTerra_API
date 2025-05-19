using XenoTerra.DTOLayer.Dtos.FollowDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.FollowMutationServices
{
    public interface IFollowSelfMutationService : IMutationService<Follow, ResultFollowDto, CreateFollowDto, UpdateFollowDto, Guid>
    {
    }
}
