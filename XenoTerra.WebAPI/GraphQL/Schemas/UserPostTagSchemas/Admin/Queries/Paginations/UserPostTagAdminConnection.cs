using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.UserPostTagDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Queries.Paginations
{
    public class UserPostTagAdminConnection(
        IReadOnlyList<Edge<ResultUserPostTagWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultUserPostTagWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
