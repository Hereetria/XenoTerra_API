using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.UserPostTagDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Queries.Paginations
{
    public class UserPostTagAdminConnection(
        IReadOnlyList<Edge<ResultUserPostTagWithRelationsAdminDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultUserPostTagWithRelationsAdminDto>(edges, pageInfo, totalCount)
    {
    }
}
