using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.SearchHistoryServices;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;

namespace XenoTerra.WebAPI.Schemas.Queries.SearchHistory
{
    public class SearchHistoryQuery
    {
        public string GetRandomData()
        {
            return "Default data to prevent query class from being empty.";
        }

        //[UseProjection]
        //[GraphQLDescription("Get all SearchHistories")]
        //public IQueryable<ResultSearchHistoryDto> GetAllSearchHistories([Service] ISearchHistoryServiceBLL searchHistoryServiceBLL)
        //{
        //    return searchHistoryServiceBLL.GetAllQuerable();
        //}

        //[UseProjection]
        //[GraphQLDescription("Get SearchHistory by ID")]
        //public IQueryable<ResultSearchHistoryByIdDto> GetSearchHistoryById(Guid id, [Service] ISearchHistoryServiceBLL searchHistoryServiceBLL)
        //{
        //    var result = searchHistoryServiceBLL.GetByIdQuerable(id);
        //    if (result == null)
        //    {
        //        throw new Exception($"SearchHistory with ID {id} not found");
        //    }
        //    return result;
        //}
    }
}
