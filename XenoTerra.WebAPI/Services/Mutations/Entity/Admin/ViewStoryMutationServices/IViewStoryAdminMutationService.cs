using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos.Admin;
namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.ViewStoryMutationServices
{
    public interface IViewStoryAdminMutationService : IMutationService<ViewStory, ResultViewStoryAdminDto, CreateViewStoryAdminDto, UpdateViewStoryAdminDto, Guid>
    {
    }
}