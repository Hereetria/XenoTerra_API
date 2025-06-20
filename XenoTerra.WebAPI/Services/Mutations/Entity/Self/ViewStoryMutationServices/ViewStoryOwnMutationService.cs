using AutoMapper;
using XenoTerra.DTOLayer.Dtos.ViewStoryAdminDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Own.ViewStoryMutationServices
{
    public class ViewStoryOwnMutationService(IMapper mapper)
        : MutationService<ViewStory, ResultViewStoryOwnDto, CreateViewStoryOwnDto, UpdateViewStoryOwnDto, Guid>(mapper),
        IViewStoryOwnMutationService
    {
    }
}
