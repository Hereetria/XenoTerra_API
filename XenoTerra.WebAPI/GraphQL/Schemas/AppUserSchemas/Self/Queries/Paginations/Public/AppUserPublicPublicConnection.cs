using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Public.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Queries.Paginations.Public
{
    public class AppUserPublicPublicConnection(
        IReadOnlyList<Edge<ResultAppUserPublicDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultAppUserPublicDto>(edges, pageInfo, totalCount)
    {
    }
}
