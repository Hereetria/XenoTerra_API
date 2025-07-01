using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.PostLikeDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Queries.Paginations.Public
{
    public class PostLikePublicConnection(
        IReadOnlyList<Edge<ResultPostLikeWithRelationsPublicDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultPostLikeWithRelationsPublicDto>(edges, pageInfo, totalCount)
    {
    }
}
