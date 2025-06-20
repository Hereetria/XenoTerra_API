using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.StoryAdminDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Queries.Paginations
{
    public class StoryAdminConnection(
        IReadOnlyList<Edge<ResultStoryWithRelationsAdminDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultStoryWithRelationsAdminDto>(edges, pageInfo, totalCount)
    {
    }
}
