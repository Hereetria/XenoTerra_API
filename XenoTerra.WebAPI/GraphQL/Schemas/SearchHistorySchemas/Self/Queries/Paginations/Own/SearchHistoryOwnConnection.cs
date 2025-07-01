using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Self.Queries.Paginations.Own
{
    public class SearchHistoryOwnConnection(
        IReadOnlyList<Edge<ResultSearchHistoryWithRelationsOwnDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultSearchHistoryWithRelationsOwnDto>(edges, pageInfo, totalCount)
    {
    }
}
