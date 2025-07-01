using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.StoryDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Queries.Paginations.Own
{
    public class StoryOwnConnection(
        IReadOnlyList<Edge<ResultStoryWithRelationsOwnDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultStoryWithRelationsOwnDto>(edges, pageInfo, totalCount)
    {
    }
}
