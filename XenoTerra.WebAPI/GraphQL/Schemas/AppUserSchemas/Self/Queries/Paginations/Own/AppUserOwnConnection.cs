using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Queries.Paginations.Own
{
    public class AppUserOwnConnection(
        IReadOnlyList<Edge<ResultAppUserWithRelationsOwnDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultAppUserWithRelationsOwnDto>(edges, pageInfo, totalCount)
    {
    }
}
