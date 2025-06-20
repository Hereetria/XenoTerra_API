using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.HighlightAdminDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Queries.Paginations
{
    public class HighlightAdminConnection(
        IReadOnlyList<Edge<ResultHighlightWithRelationsAdminDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultHighlightWithRelationsAdminDto>(edges, pageInfo, totalCount)
    {
    }
}
