using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.MessageDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Queries.Paginations
{
    public class MessageConnection(
        IReadOnlyList<Edge<ResultMessageWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultMessageWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
