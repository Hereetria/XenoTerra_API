using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.StoryMutationServices
{
    public interface IStoryAdminMutationService : IMutationService<Story, ResultStoryDto, CreateStoryDto, UpdateStoryDto, Guid>
    {
    }
}
