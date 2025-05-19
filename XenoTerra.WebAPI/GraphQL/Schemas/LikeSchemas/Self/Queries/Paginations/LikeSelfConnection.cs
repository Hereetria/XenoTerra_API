using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.LikeDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Self.Queries.Paginations
{
    public class LikeSelfConnection(
        IReadOnlyList<Edge<ResultLikeWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultLikeWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
