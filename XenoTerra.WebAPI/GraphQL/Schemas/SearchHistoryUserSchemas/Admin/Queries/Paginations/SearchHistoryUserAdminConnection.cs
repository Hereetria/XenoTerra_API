using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.SearchHistoryUserAdminDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Queries.Paginations
{
    public class SearchHistoryUserAdminConnection(
        IReadOnlyList<Edge<ResultSearchHistoryUserWithRelationsAdminDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultSearchHistoryUserWithRelationsAdminDto>(edges, pageInfo, totalCount)
    {
    }
}
