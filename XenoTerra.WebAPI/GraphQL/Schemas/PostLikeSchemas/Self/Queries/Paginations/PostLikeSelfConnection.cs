using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.PostLikeDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Queries.Paginations
{
    public class PostLikeSelfConnection(
        IReadOnlyList<Edge<ResultPostLikeWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultPostLikeWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
