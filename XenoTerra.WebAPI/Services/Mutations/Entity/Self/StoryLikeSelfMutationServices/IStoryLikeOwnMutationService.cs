using XenoTerra.DTOLayer.Dtos.StoryLikeDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Own.StoryLikeOwnMutationServices
{
    public interface IStoryLikeOwnMutationService : IMutationService<StoryLike, ResultStoryLikeOwnDto, CreateStoryLikeOwnDto, UpdateStoryLikeOwnDto, Guid>
    {
    }
}
