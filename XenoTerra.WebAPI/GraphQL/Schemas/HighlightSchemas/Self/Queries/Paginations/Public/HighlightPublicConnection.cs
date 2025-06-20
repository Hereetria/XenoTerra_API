using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.HighlightAdminDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Queries.Paginations.Public
{
    public class HighlightPublicConnection(
        IReadOnlyList<Edge<ResultHighlightPublicDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultHighlightPublicDto>(edges, pageInfo, totalCount)
    {
    }
}
