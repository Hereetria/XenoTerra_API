using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.CommentLikeDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Queries.Paginations
{
    public class CommentLikeSelfConnection(
        IReadOnlyList<Edge<ResultCommentLikeWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultCommentLikeWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
