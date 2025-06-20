using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.AppRoleDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppRoleSchemas.Admin.Queries.Paginations
{
    public class AppRoleAdminConnection(
        IReadOnlyList<Edge<ResultAppRoleWithRelationsAdminDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultAppRoleWithRelationsAdminDto>(edges, pageInfo, totalCount)
    {
    }
}
