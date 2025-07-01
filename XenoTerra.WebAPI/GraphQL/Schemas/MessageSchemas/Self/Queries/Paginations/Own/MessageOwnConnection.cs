using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.MessageDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Queries.Paginations.Own
{
    public class MessageOwnConnection(
        IReadOnlyList<Edge<ResultMessageWithRelationsOwnDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultMessageWithRelationsOwnDto>(edges, pageInfo, totalCount)
    {
    }
}
