
using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.DataAccessLayer.Repositories;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Services.StoryServices
{
    
    public interface IStoryServiceDAL : IGenericRepositoryDAL<Story, ResultStoryDto, ResultStoryByIdDto ,CreateStoryDto, UpdateStoryDto, Guid>

    {
        IQueryable<ResultStoryDto> GetFollowingStories(Guid userId);
    }
}