using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Admin.Queries.Paginations
{
    public class ViewStoryAdminConnection(
        IReadOnlyList<Edge<ResultViewStoryWithRelationsAdminDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultViewStoryWithRelationsAdminDto>(edges, pageInfo, totalCount)
    {
    }
}
