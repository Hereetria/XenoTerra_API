using AutoMapper;
using XenoTerra.DTOLayer.Dtos.StoryAdminDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Own.StoryMutationServices
{
    public class StoryOwnMutationService(IMapper mapper)
        : MutationService<Story, ResultStoryOwnDto, CreateStoryOwnDto, UpdateStoryOwnDto, Guid>(mapper),
        IStoryOwnMutationService
    {
    }
}
