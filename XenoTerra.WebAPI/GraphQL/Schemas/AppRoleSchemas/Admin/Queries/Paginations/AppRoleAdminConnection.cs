using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.AppRoleDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppRoleSchemas.Admin.Queries.Paginations
{
    public class AppRoleAdminConnection(
        IReadOnlyList<Edge<ResultAppRoleWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultAppRoleWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
