using AutoMapper;
using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.StoryMutationServices
{
    public class StoryAdminMutationService(IMapper mapper)
        : MutationService<Story, ResultStoryDto, CreateStoryDto, UpdateStoryDto, Guid>(mapper),
        IStoryAdminMutationService
    {
    }
}
