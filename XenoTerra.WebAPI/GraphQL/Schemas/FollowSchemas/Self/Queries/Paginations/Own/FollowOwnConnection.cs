using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.FollowDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Queries.Paginations.Own
{
    public class FollowOwnConnection(
        IReadOnlyList<Edge<ResultFollowWithRelationsOwnDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultFollowWithRelationsOwnDto>(edges, pageInfo, totalCount)
    {
    }
}
