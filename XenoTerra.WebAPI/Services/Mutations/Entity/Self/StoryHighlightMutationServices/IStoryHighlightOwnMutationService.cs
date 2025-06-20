using XenoTerra.DTOLayer.Dtos.StoryHighlightAdminDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Own.StoryHighlightMutationServices
{
    public interface IStoryHighlightOwnMutationService : IMutationService<StoryHighlight, ResultStoryHighlightOwnDto, CreateStoryHighlightOwnDto, UpdateStoryHighlightOwnDto, Guid>
    {
    }
}
