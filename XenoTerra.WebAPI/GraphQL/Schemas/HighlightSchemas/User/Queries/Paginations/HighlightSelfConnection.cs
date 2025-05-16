using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Queries.Paginations
{
    public class HighlightSelfConnection(
        IReadOnlyList<Edge<ResultHighlightWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultHighlightWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
