using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.DTOLayer.Dtos.ViewStoryAdminDtos.Admin;
namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.ViewStoryMutationServices
{
    public class ViewStoryAdminMutationService(IMapper mapper)
        : MutationService<ViewStory, ResultViewStoryAdminDto, CreateViewStoryAdminDto, UpdateViewStoryAdminDto, Guid>(mapper),
        IViewStoryAdminMutationService
    {
    }
}