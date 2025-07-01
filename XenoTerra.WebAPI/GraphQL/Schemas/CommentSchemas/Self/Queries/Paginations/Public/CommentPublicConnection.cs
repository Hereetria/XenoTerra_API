using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.CommentDtos.Self.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Queries.Paginations.Public
{
    public class CommentPublicConnection(
        IReadOnlyList<Edge<ResultCommentWithRelationsPublicDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultCommentWithRelationsPublicDto>(edges, pageInfo, totalCount)
    {
    }
}
