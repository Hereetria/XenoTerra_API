using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.AppUserDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Admin.Queries.Paginations
{
    public class AppUserAdminConnection(
        IReadOnlyList<Edge<ResultAppUserWithRelationsPrivateDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultAppUserWithRelationsPrivateDto>(edges, pageInfo, totalCount)
    {
    }
}
