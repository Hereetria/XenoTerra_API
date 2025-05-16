using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.RoleDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Queries.Paginations
{
    public class RoleAdminConnection(
        IReadOnlyList<Edge<ResultRoleWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultRoleWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
