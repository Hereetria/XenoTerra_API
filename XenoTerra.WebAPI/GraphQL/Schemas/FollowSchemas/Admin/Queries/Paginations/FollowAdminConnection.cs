using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.FollowDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Queries.Paginations
{
    public class FollowAdminConnection(
        IReadOnlyList<Edge<ResultFollowWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultFollowWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
