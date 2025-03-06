using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.SearchHistoryUserServices;
using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos;

namespace XenoTerra.WebAPI.Schemas.Queries.SearchHistoryUser
{
    public class SearchHistoryUserQuery
    {
        [UseProjection]
        public IQueryable<ResultSearchHistoryUserWithRelationsDto> GetSearchHistoryUsers(List<Guid>? ids, [Service] ISearchHistoryUserServiceBLL service)
    => ids != null && ids.Any() ? service.GetByIdsQuerable(ids) : service.GetByIdsQuerable(service.GetAllIdsAsync().Result);
        //[UseProjection]
        //[GraphQLDescription("Get all SearchHistoryUsers")]
        //public IQueryable<ResultSearchHistoryUserDto> GetAllSearchHistoryUsers([Service] ISearchHistoryUserServiceBLL searchHistoryUserServiceBLL)
        //{
        //    return searchHistoryUserServiceBLL.GetAllQuerable();
        //}

        //[UseProjection]
        //[GraphQLDescription("Get SearchHistoryUser by ID")]
        //public IQueryable<ResultSearchHistoryUserByIdDto> GetSearchHistoryUserById(Guid id, [Service] ISearchHistoryUserServiceBLL searchHistoryUserServiceBLL)
        //{
        //    var result = searchHistoryUserServiceBLL.GetByIdQuerable(id);
        //    if (result == null)
        //    {
        //        throw new Exception($"SearchHistoryUser with ID {id} not found");
        //    }
        //    return result;
        //}
    }
}
