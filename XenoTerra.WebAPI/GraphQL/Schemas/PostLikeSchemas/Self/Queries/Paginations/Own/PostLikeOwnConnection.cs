using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.PostLikeDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Queries.Paginations.Own
{
    public class PostLikeOwnConnection(
        IReadOnlyList<Edge<ResultPostLikeWithRelationsOwnDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultPostLikeWithRelationsOwnDto>(edges, pageInfo, totalCount)
    {
    }
}
