using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.ViewStoryAdminDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Admin.Queries.Paginations
{
    public class ViewStoryAdminConnection(
        IReadOnlyList<Edge<ResultViewStoryWithRelationsAdminDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultViewStoryWithRelationsAdminDto>(edges, pageInfo, totalCount)
    {
    }
}
