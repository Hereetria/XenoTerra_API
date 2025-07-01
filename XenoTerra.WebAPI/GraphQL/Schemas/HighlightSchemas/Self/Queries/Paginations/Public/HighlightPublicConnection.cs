using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.HighlightDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Queries.Paginations.Public
{
    public class HighlightPublicConnection(
        IReadOnlyList<Edge<ResultHighlightWithRelationsPublicDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultHighlightWithRelationsPublicDto>(edges, pageInfo, totalCount)
    {
    }
}
