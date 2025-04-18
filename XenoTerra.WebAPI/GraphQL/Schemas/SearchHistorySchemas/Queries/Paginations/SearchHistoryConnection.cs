using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Queries.Paginations
{
    public class SearchHistoryConnection(
        IReadOnlyList<Edge<ResultSearchHistoryWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultSearchHistoryWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
