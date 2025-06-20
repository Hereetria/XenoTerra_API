using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.ReactionAdminDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Queries.Paginations.Own
{
    public class ReactionOwnConnection(
        IReadOnlyList<Edge<ResultReactionWithRelationsOwnDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultReactionWithRelationsOwnDto>(edges, pageInfo, totalCount)
    {
    }
}
