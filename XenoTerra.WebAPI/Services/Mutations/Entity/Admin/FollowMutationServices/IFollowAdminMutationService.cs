using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.DTOLayer.Dtos.FollowDtos.Admin;
namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.FollowMutationServices
{
    public interface IFollowAdminMutationService : IMutationService<Follow, ResultFollowAdminDto, CreateFollowAdminDto, UpdateFollowAdminDto, Guid>
    {
    }
}