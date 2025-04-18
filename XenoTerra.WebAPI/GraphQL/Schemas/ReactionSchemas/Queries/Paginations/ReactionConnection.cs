using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.ReactionDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Queries.Paginations
{
    public class ReactionConnection(
        IReadOnlyList<Edge<ResultReactionWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultReactionWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
