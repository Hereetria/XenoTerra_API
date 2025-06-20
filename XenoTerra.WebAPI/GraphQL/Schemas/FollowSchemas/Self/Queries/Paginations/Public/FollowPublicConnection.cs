using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.FollowAdminDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Queries.Paginations.Public
{
    public class FollowPublicConnection(
        IReadOnlyList<Edge<ResultFollowPublicDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultFollowPublicDto>(edges, pageInfo, totalCount)
    {
    }
}
