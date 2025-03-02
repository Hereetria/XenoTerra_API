using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.StoryServices;
using XenoTerra.DTOLayer.Dtos.StoryDtos;

namespace XenoTerra.WebAPI.Schemas.Queries.Story
{
    public class StoryQuery
    {
        [UseProjection]
        [GraphQLDescription("Get all Stories")]
        public IQueryable<ResultStoryDto> GetAllStories([Service] IStoryServiceBLL storyServiceBLL)
        {
            return storyServiceBLL.GetAllQuerable();
        }

        [UseProjection]
        [GraphQLDescription("Get Story by ID")]
        public IQueryable<ResultStoryByIdDto> GetStoryById(Guid id, [Service] IStoryServiceBLL storyServiceBLL)
        {
            var result = storyServiceBLL.GetByIdQuerable(id);
            if (result == null)
            {
                throw new Exception($"Story with ID {id} not found");
            }
            return result;
        }
    }
}
