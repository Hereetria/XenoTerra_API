using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.SearchHistoryAdminDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Queries.Paginations
{
    public class SearchHistoryAdminConnection(
        IReadOnlyList<Edge<ResultSearchHistoryWithRelationsAdminDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultSearchHistoryWithRelationsAdminDto>(edges, pageInfo, totalCount)
    {
    }
}
