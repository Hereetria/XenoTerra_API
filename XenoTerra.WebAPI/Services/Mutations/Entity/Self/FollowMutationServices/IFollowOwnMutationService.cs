using XenoTerra.DTOLayer.Dtos.FollowAdminDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Own.FollowMutationServices
{
    public interface IFollowOwnMutationService : IMutationService<Follow, ResultFollowOwnDto, CreateFollowOwnDto, UpdateFollowOwnDto, Guid>
    {
    }
}
