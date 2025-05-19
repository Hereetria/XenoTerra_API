using XenoTerra.DTOLayer.Dtos.FollowDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.FollowMutationServices
{
    public interface IFollowAdminMutationService : IMutationService<Follow, ResultFollowDto, CreateFollowDto, UpdateFollowDto, Guid>
    {
    }
}
