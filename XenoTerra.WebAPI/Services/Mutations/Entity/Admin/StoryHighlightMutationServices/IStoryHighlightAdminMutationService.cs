using XenoTerra.DTOLayer.Dtos.StoryHighlightDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.StoryHighlightMutationServices
{
    public interface IStoryHighlightAdminMutationService : IMutationService<StoryHighlight, ResultStoryHighlightDto, CreateStoryHighlightDto, UpdateStoryHighlightDto, Guid>
    {
    }
}
