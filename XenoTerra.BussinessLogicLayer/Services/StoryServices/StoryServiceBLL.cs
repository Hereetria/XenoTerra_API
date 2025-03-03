
using XenoTerra.EntityLayer.Entities;
using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.BussinessLogicLayer.Services.StoryServices;
using XenoTerra.DataAccessLayer.Factories.Abstract;
using XenoTerra.DataAccessLayer.Services.StoryServices;

namespace XenoTerra.BussinessLogicLayer.Services.StoryServices
{
     public class StoryServiceBLL : GenericRepositoryBLL<Story, ResultStoryDto, ResultStoryByIdDto, CreateStoryDto, UpdateStoryDto, Guid>, IStoryServiceBLL
    {
        private readonly IStoryServiceDAL _storyServiceDAL;
        public StoryServiceBLL(IGenericRepositoryDALFactory repositoryDALFactory, IStoryServiceDAL storyServiceDAL)
            : base(repositoryDALFactory)
        {
            _storyServiceDAL = storyServiceDAL;
        }

        public IQueryable<ResultStoryDto> GetFollowingStories(Guid userId)
        {
            var result = _storyServiceDAL.TGetFollowingStories(userId);
            return result;
        }
    }
}