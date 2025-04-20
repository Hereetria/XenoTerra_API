using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.StoryHighlightDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Queries.Paginations
{
    public class StoryHighlightConnection(
        IReadOnlyList<Edge<ResultStoryHighlightWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultStoryHighlightWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
