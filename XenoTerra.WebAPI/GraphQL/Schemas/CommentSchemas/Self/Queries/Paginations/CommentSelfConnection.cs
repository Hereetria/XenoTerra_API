using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.CommentDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Queries.Paginations
{
    public class CommentSelfConnection(
        IReadOnlyList<Edge<ResultCommentWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultCommentWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
