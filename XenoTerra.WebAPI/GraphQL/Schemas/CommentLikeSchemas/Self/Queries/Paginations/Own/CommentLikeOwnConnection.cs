using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.CommentLikeAdminDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Queries.Paginations.Own
{
    public class CommentLikeOwnConnection(
        IReadOnlyList<Edge<ResultCommentLikeWithRelationsOwnDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultCommentLikeWithRelationsOwnDto>(edges, pageInfo, totalCount)
    {
    }
}
