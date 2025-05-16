using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.LikeDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Queries.Paginations
{
    public class LikeAdminConnection(
        IReadOnlyList<Edge<ResultLikeWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultLikeWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
