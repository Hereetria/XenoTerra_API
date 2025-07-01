using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.DTOLayer.Dtos.StoryDtos.Admin;
namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.StoryMutationServices
{
    public interface IStoryAdminMutationService : IMutationService<Story, ResultStoryAdminDto, CreateStoryAdminDto, UpdateStoryAdminDto, Guid>
    {
    }
}