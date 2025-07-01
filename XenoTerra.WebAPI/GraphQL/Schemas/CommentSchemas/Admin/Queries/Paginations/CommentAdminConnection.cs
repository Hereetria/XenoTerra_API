using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.CommentDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Queries.Paginations
{
    public class CommentAdminConnection(
        IReadOnlyList<Edge<ResultCommentWithRelationsAdminDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultCommentWithRelationsAdminDto>(edges, pageInfo, totalCount)
    {
    }
}
