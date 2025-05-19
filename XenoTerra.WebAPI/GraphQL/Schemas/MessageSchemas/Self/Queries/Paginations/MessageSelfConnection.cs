using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.MessageDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Queries.Paginations
{
    public class MessageSelfConnection(
        IReadOnlyList<Edge<ResultMessageWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultMessageWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
