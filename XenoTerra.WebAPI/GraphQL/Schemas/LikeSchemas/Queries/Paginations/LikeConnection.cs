using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.LikeDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Queries.Paginations
{
    public class LikeConnection(
        IReadOnlyList<Edge<ResultLikeWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultLikeWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
