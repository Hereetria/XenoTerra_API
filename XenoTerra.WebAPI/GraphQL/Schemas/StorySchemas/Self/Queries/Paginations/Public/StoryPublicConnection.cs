using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.StoryDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Queries.Paginations.Public
{
    public class StoryPublicConnection(
        IReadOnlyList<Edge<ResultStoryWithRelationsPublicDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultStoryWithRelationsPublicDto>(edges, pageInfo, totalCount)
    {
    }
}
