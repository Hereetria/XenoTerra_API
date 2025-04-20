using AutoMapper;
using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.StoryMutationServices
{
    public class StoryMutationService(IMapper mapper)
        : MutationService<Story, ResultStoryDto, CreateStoryDto, UpdateStoryDto, Guid>(mapper),
        IStoryMutationService
    {
    }
}
