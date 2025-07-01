using XenoTerra.DTOLayer.Dtos.StoryHighlightDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.StoryHighlightMutationServices
{
    public interface IStoryHighlightOwnMutationService : IMutationService<StoryHighlight, ResultStoryHighlightOwnDto, CreateStoryHighlightOwnDto, UpdateStoryHighlightOwnDto, Guid>
    {
    }
}
