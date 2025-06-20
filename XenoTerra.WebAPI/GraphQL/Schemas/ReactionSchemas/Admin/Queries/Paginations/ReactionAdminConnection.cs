using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.ReactionAdminDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Queries.Paginations
{
    public class ReactionAdminConnection(
        IReadOnlyList<Edge<ResultReactionWithRelationsAdminDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultReactionWithRelationsAdminDto>(edges, pageInfo, totalCount)
    {
    }
}
