using XenoTerra.DTOLayer.Dtos.StoryHighlightDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.StoryHighlightMutationServices
{
    public interface IStoryHighlightSelfMutationService : IMutationService<StoryHighlight, ResultStoryHighlightDto, CreateStoryHighlightDto, UpdateStoryHighlightDto, Guid>
    {
    }
}
