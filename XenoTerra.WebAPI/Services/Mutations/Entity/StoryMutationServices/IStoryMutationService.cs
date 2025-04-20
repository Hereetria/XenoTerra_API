using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.StoryMutationServices
{
    public interface IStoryMutationService : IMutationService<Story, ResultStoryDto, CreateStoryDto, UpdateStoryDto, Guid>
    {
    }
}
