using AutoMapper;
using XenoTerra.DTOLayer.Dtos.StoryHighlightDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.StoryHighlightMutationServices
{
    public class StoryHighlightOwnMutationService(IMapper mapper)
        : MutationService<StoryHighlight, ResultStoryHighlightOwnDto, CreateStoryHighlightOwnDto, UpdateStoryHighlightOwnDto, Guid>(mapper),
        IStoryHighlightOwnMutationService
    {
    }
}
