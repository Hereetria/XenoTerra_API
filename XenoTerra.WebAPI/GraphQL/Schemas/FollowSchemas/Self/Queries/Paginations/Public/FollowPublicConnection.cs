using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.FollowDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Queries.Paginations.Public
{
    public class FollowPublicConnection(
        IReadOnlyList<Edge<ResultFollowWithRelationsPublicDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultFollowWithRelationsPublicDto>(edges, pageInfo, totalCount)
    {
    }
}
