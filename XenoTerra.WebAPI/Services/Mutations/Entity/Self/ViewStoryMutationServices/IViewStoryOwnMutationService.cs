using XenoTerra.DTOLayer.Dtos.ViewStoryAdminDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Own.ViewStoryMutationServices
{
    public interface IViewStoryOwnMutationService : IMutationService<ViewStory, ResultViewStoryOwnDto, CreateViewStoryOwnDto, UpdateViewStoryOwnDto, Guid>
    {
    }
}
