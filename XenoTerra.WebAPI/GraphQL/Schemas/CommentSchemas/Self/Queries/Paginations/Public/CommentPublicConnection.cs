using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.CommentAdminDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Queries.Paginations.Public
{
    public class CommentPublicConnection(
        IReadOnlyList<Edge<ResultCommentPublicDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultCommentPublicDto>(edges, pageInfo, totalCount)
    {
    }
}
