using AutoMapper;
using XenoTerra.DTOLayer.Dtos.StoryHighlightDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.StoryHighlightMutationServices
{
    public class StoryHighlightSelfMutationService(IMapper mapper)
        : MutationService<StoryHighlight, ResultStoryHighlightDto, CreateStoryHighlightDto, UpdateStoryHighlightDto, Guid>(mapper),
        IStoryHighlightSelfMutationService
    {
    }
}
