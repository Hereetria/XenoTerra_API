using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.AppUserDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Queries.Paginations
{
    public class AppUserPublicSelfConnection(
        IReadOnlyList<Edge<ResultAppUserWithRelationsPublicDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultAppUserWithRelationsPublicDto>(edges, pageInfo, totalCount)
    {
    }
}
