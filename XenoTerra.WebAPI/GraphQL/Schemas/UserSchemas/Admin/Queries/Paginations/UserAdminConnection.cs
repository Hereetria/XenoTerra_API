using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Admin.Queries.Paginations
{
    public class UserAdminConnection(
        IReadOnlyList<Edge<ResultUserWithRelationsPrivateDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultUserWithRelationsPrivateDto>(edges, pageInfo, totalCount)
    {
    }
}
