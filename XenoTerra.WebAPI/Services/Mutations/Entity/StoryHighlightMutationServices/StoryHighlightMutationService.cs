using AutoMapper;
using XenoTerra.DTOLayer.Dtos.StoryHighlightDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.StoryHighlightMutationServices
{
    public class StoryHighlightMutationService(IMapper mapper)
        : MutationService<StoryHighlight, ResultStoryHighlightDto, CreateStoryHighlightDto, UpdateStoryHighlightDto, Guid>(mapper),
        IStoryHighlightMutationService
    {
    }
}
