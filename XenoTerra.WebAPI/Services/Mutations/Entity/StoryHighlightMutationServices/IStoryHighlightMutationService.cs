using XenoTerra.DTOLayer.Dtos.StoryHighlightDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.StoryHighlightMutationServices
{
    public interface IStoryHighlightMutationService : IMutationService<StoryHighlight, ResultStoryHighlightDto, CreateStoryHighlightDto, UpdateStoryHighlightDto, Guid>
    {
    }
}
