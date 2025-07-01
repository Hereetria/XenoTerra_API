using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Queries.Paginations.Public
{
    public class AppUserPublicConnection(
        IReadOnlyList<Edge<ResultAppUserWithRelationsPublicDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultAppUserWithRelationsPublicDto>(edges, pageInfo, totalCount)
    {
    }
}
