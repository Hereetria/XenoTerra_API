using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.ViewStoryServices;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;

namespace XenoTerra.WebAPI.Schemas.Queries.ViewStory
{
    public class ViewStoryQuery
    {
        public string GetRandomData()
        {
            return "Default data to prevent query class from being empty.";
        }

        //[GraphQLDescription("Get all ViewStories")]
        //public IQueryable<ResultViewStoryDto> GetAllViewStories([Service] IViewStoryServiceBLL viewStoryServiceBLL)
        //{
        //    return viewStoryServiceBLL.GetAllQuerable();
        //}

        //[UseProjection]
        //[GraphQLDescription("Get ViewStory by ID")]
        //public IQueryable<ResultViewStoryByIdDto> GetViewStoryById(Guid id, [Service] IViewStoryServiceBLL viewStoryServiceBLL)
        //{
        //    var result = viewStoryServiceBLL.GetByIdQuerable(id);
        //    if (result == null)
        //    {
        //        throw new Exception($"ViewStory with ID {id} not found");
        //    }
        //    return result;
        //}
    }
}