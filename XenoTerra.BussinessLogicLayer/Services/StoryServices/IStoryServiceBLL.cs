
using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.EntityLayer.Entities;
namespace XenoTerra.BussinessLogicLayer.Services.StoryServices
{
        public interface IStoryServiceBLL : IGenericRepositoryBLL<Story, ResultStoryDto, ResultStoryWithRelationsDto, CreateStoryDto, UpdateStoryDto, Guid>
    {
        IQueryable<ResultStoryDto> GetFollowingStories(Guid userId);
    }
}