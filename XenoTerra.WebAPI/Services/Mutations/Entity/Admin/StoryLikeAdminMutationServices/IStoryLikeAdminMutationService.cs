using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.DTOLayer.Dtos.StoryLikeDtos.Admin;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.StoryLikeAdminMutationServices
{
    public interface IStoryLikeAdminMutationService : IMutationService<StoryLike, ResultStoryLikeAdminDto, CreateStoryLikeAdminDto, UpdateStoryLikeAdminDto, Guid>
    {
    }
}