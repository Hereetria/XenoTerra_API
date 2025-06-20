using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Own.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Queries.Paginations.Own
{
    public class AppUserPublicOwnConnection(
        IReadOnlyList<Edge<ResultAppUserWithRelationsPublicDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultAppUserWithRelationsPublicDto>(edges, pageInfo, totalCount)
    {
    }
}
