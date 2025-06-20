using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.CommentLikeAdminDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Queries.Paginations.Public
{
    public class CommentLikePublicConnection(
        IReadOnlyList<Edge<ResultCommentLikePublicDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultCommentLikePublicDto>(edges, pageInfo, totalCount)
    {
    }
}
