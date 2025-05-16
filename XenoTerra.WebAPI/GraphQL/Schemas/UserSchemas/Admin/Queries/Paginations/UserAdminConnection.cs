using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Queries.Paginations
{
    public class UserAdminConnection(
        IReadOnlyList<Edge<ResultUserWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultUserWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
