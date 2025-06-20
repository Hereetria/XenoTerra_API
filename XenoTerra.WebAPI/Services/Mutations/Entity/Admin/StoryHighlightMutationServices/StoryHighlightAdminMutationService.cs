using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.DTOLayer.Dtos.StoryHighlightAdminDtos.Admin;
namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.StoryHighlightMutationServices
{
    public class StoryHighlightAdminMutationService(IMapper mapper)
        : MutationService<StoryHighlight, ResultStoryHighlightAdminDto, CreateStoryHighlightAdminDto, UpdateStoryHighlightAdminDto, Guid>(mapper),
        IStoryHighlightAdminMutationService
    {
    }
}