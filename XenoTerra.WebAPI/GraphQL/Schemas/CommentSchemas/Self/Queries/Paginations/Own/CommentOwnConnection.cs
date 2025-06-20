using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.CommentAdminDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Queries.Paginations.Own
{
    public class CommentOwnConnection(
        IReadOnlyList<Edge<ResultCommentWithRelationsOwnDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultCommentWithRelationsOwnDto>(edges, pageInfo, totalCount)
    {
    }
}
