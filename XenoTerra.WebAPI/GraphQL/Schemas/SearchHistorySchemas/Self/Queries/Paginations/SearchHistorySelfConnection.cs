using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Self.Queries.Paginations
{
    public class SearchHistorySelfConnection(
        IReadOnlyList<Edge<ResultSearchHistoryWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultSearchHistoryWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
