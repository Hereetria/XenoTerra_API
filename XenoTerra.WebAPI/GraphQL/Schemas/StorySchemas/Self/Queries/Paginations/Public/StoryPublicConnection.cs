using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.StoryAdminDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Queries.Paginations.Public
{
    public class StoryPublicConnection(
        IReadOnlyList<Edge<ResultStoryPublicDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultStoryPublicDto>(edges, pageInfo, totalCount)
    {
    }
}
