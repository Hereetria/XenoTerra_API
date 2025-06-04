using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.AppUserDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Queries.Paginations
{
    public class AppUserPrivateSelfConnection(
        IReadOnlyList<Edge<ResultAppUserWithRelationsPrivateDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultAppUserWithRelationsPrivateDto>(edges, pageInfo, totalCount)
    {
    }
}
