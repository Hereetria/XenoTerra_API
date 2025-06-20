using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.FollowAdminDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Queries.Paginations
{
    public class FollowAdminConnection(
        IReadOnlyList<Edge<ResultFollowWithRelationsAdminDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultFollowWithRelationsAdminDto>(edges, pageInfo, totalCount)
    {
    }
}
