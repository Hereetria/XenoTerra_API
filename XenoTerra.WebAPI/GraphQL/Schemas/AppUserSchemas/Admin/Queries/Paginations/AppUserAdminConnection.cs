using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Admin.Queries.Paginations
{
    public class AppUserAdminConnection(
        IReadOnlyList<Edge<ResultAppUserWithRelationsOwnDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultAppUserWithRelationsOwnDto>(edges, pageInfo, totalCount)
    {
    }
}
