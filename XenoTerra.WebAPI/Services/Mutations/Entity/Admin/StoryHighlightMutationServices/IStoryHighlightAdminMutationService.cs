using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.DTOLayer.Dtos.StoryHighlightAdminDtos.Admin;
namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.StoryHighlightMutationServices
{
    public interface IStoryHighlightAdminMutationService : IMutationService<StoryHighlight, ResultStoryHighlightAdminDto, CreateStoryHighlightAdminDto, UpdateStoryHighlightAdminDto, Guid>
    {
    }
}