using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Self.Queries.Paginations
{
    public class UserPublicSelfConnection(
        IReadOnlyList<Edge<ResultUserWithRelationsPublicDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultUserWithRelationsPublicDto>(edges, pageInfo, totalCount)
    {
    }
}
