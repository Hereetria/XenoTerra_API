using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.StoryDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Queries.Paginations
{
    public class StorySelfConnection(
        IReadOnlyList<Edge<ResultStoryWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultStoryWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
