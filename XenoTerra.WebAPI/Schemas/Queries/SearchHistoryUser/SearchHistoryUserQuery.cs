namespace XenoTerra.WebAPI.Schemas.Queries.SearchHistoryUser
{
    public class SearchHistoryUserQuery
    {
        public string GetRandomData()
        {
            return "Default data to prevent query class from being empty.";
        }

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
