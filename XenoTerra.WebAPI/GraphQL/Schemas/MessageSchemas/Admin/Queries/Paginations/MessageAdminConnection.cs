using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.MessageDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Queries.Paginations
{
    public class MessageAdminConnection(
        IReadOnlyList<Edge<ResultMessageWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultMessageWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
