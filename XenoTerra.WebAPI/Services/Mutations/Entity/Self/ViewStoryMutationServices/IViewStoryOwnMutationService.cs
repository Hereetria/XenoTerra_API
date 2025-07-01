using XenoTerra.DTOLayer.Dtos.ViewStoryDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.ViewStoryMutationServices
{
    public interface IViewStoryOwnMutationService : IMutationService<ViewStory, ResultViewStoryOwnDto, CreateViewStoryOwnDto, UpdateViewStoryOwnDto, Guid>
    {
    }
}
