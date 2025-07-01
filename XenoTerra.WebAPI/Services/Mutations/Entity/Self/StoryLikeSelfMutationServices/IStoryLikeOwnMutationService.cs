using XenoTerra.DTOLayer.Dtos.StoryLikeDtos;
using XenoTerra.DTOLayer.Dtos.StoryLikeDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.StoryLikeSelfMutationServices
{
    public interface IStoryLikeOwnMutationService : IMutationService<StoryLike, ResultStoryLikeOwnDto, CreateStoryLikeOwnDto, UpdateStoryLikeOwnDto, Guid>
    {
    }
}
