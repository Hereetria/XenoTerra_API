using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.CommentLikeDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Queries.Paginations.Public
{
    public class CommentLikePublicConnection(
        IReadOnlyList<Edge<ResultCommentLikeWithRelationsPublicDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultCommentLikeWithRelationsPublicDto>(edges, pageInfo, totalCount)
    {
    }
}
