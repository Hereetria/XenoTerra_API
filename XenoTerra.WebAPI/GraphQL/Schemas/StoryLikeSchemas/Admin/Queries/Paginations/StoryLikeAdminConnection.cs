using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.StoryLikeDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Admin.Queries.Paginations
{
    public class StoryLikeAdminConnection(
        IReadOnlyList<Edge<ResultStoryLikeWithRelationsAdminDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultStoryLikeWithRelationsAdminDto>(edges, pageInfo, totalCount)
    {
    }
}
