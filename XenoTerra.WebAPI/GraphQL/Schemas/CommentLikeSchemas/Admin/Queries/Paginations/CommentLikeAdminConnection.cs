using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.CommentLikeDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Admin.Queries.Paginations
{
    public class CommentLikeAdminConnection(
        IReadOnlyList<Edge<ResultCommentLikeWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultCommentLikeWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
