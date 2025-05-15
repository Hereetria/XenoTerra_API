using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.CommentDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Queries.Paginations
{
    public class CommentConnection(
        IReadOnlyList<Edge<ResultCommentWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultCommentWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
