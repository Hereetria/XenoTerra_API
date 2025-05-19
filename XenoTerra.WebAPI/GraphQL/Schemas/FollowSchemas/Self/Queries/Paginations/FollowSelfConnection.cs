using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.FollowDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Queries.Paginations
{
    public class FollowSelfConnection(
        IReadOnlyList<Edge<ResultFollowWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultFollowWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
