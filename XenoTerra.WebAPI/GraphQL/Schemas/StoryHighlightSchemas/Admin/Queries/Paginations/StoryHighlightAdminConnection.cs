using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.StoryHighlightDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Queries.Paginations
{
    public class StoryHighlightAdminConnection(
        IReadOnlyList<Edge<ResultStoryHighlightWithRelationsAdminDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultStoryHighlightWithRelationsAdminDto>(edges, pageInfo, totalCount)
    {
    }
}
