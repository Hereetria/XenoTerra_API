using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.ViewStoryMutationServices
{
    public interface IViewStorySelfMutationService : IMutationService<ViewStory, ResultViewStoryDto, CreateViewStoryDto, UpdateViewStoryDto, Guid>
    {
    }
}
