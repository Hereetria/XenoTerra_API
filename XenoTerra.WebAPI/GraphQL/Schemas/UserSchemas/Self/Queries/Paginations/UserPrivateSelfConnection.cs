using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Self.Queries.Paginations
{
    public class UserPrivateSelfConnection(
        IReadOnlyList<Edge<ResultUserWithRelationsPrivateDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultUserWithRelationsPrivateDto>(edges, pageInfo, totalCount)
    {
    }
}
