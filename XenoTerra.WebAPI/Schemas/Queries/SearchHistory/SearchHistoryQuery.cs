using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.SearchHistoryServices;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;

namespace XenoTerra.WebAPI.Schemas.Queries.SearchHistory
{
    public class SearchHistoryQuery
    {
        [UseProjection]
        public IQueryable<ResultSearchHistoryDto> GetSearchHistories(List<Guid>? ids, [Service] ISearchHistoryServiceBLL service)
    => ids != null && ids.Any() ? service.GetByIdsQuerable(ids) : service.GetByIdsQuerable(service.GetAllIdsAsync().Result);
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
