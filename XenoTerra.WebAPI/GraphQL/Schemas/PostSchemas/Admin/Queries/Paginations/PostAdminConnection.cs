using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.PostDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Queries.Paginations
{
    public class PostAdminConnection(
        IReadOnlyList<Edge<ResultPostWithRelationsAdminDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultPostWithRelationsAdminDto>(edges, pageInfo, totalCount)
    {
    }
}
