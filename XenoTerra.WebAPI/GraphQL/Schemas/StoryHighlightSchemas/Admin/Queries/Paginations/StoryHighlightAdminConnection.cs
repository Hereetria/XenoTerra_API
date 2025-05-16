using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.StoryHighlightDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Queries.Paginations
{
    public class StoryHighlightAdminConnection(
        IReadOnlyList<Edge<ResultStoryHighlightWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultStoryHighlightWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
