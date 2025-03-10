using XenoTerra.DTOLayer.Dtos.StoryDtos;

namespace XenoTerra.WebAPI.Schemas.Queries.Story
{
    public class StoryQuery
    {
        public string GetRandomData()
        {
            return "Default data to prevent query class from being empty.";
        }

        //[UseProjection]
        //[GraphQLDescription("Get all Stories")]
        //public IQueryable<ResultStoryDto> GetAllStories([Service] IStoryServiceBLL storyServiceBLL)
        //{
        //    return storyServiceBLL.GetAllQuerable();
        //}

        //[UseProjection]
        //[GraphQLDescription("Get Story by ID")]
        //public IQueryable<ResultStoryByIdDto> GetStoryById(Guid id, [Service] IStoryServiceBLL storyServiceBLL)
        //{
        //    var result = storyServiceBLL.GetByIdQuerable(id);
        //    if (result == null)
        //    {
        //        throw new Exception($"Story with ID {id} not found");
        //    }
        //    return result;
        //}

        //[UseProjection]
        //[GraphQLDescription("Get following users stories")]
        //public IQueryable<ResultStoryDto> GetFollowingStories([Service] IStoryServiceBLL storyServiceBLL)
        //{
        //    var userId = Guid.Parse("bc9fddb5-ed1d-448d-a8a8-08dd5962d80d");
        //    var result = storyServiceBLL.GetFollowingStories(userId);
        //    return result;
        //}
    }
}
