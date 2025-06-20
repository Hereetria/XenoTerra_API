using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.DTOLayer.Dtos.StoryAdminDtos.Admin;
namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.StoryMutationServices
{
    public class StoryAdminMutationService(IMapper mapper)
        : MutationService<Story, ResultStoryAdminDto, CreateStoryAdminDto, UpdateStoryAdminDto, Guid>(mapper),
        IStoryAdminMutationService
    {
    }
}