using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Admin.Queries.Paginations
{
    public class ViewStoryAdminConnection(
        IReadOnlyList<Edge<ResultViewStoryWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultViewStoryWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
