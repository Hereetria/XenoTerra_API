using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.CommentLikeAdminDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Admin.Queries.Paginations
{
    public class CommentLikeAdminConnection(
        IReadOnlyList<Edge<ResultCommentLikeWithRelationsAdminDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultCommentLikeWithRelationsAdminDto>(edges, pageInfo, totalCount)
    {
    }
}
