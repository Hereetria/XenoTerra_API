using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Queries.Paginations
{
    public class SearchHistoryUserAdminConnection(
        IReadOnlyList<Edge<ResultSearchHistoryUserWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultSearchHistoryUserWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
