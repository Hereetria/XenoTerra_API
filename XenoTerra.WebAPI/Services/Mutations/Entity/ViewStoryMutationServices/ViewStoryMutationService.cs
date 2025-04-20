using AutoMapper;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.ViewStoryMutationServices
{
    public class ViewStoryMutationService(IMapper mapper)
        : MutationService<ViewStory, ResultViewStoryDto, CreateViewStoryDto, UpdateViewStoryDto, Guid>(mapper),
        IViewStoryMutationService
    {
    }
}
