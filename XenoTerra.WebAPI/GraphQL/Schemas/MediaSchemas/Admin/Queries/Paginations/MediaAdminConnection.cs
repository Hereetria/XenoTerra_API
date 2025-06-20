using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.MediaAdminDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Queries.Paginations
{
    public class MediaAdminConnection(
        IReadOnlyList<Edge<ResultMediaWithRelationsAdminDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultMediaWithRelationsAdminDto>(edges, pageInfo, totalCount)
    {
    }
}
