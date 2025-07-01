using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.StoryLikeDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Self.Queries.Paginations.Own
{
    public class StoryLikeOwnConnection(
        IReadOnlyList<Edge<ResultStoryLikeWithRelationsOwnDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultStoryLikeWithRelationsOwnDto>(edges, pageInfo, totalCount)
    {
    }
}
