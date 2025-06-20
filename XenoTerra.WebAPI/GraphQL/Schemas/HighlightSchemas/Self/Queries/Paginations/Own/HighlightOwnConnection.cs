using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.HighlightAdminDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Queries.Paginations.Own
{
    public class HighlightOwnConnection(
        IReadOnlyList<Edge<ResultHighlightWithRelationsOwnDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultHighlightWithRelationsOwnDto>(edges, pageInfo, totalCount)
    {
    }
}
