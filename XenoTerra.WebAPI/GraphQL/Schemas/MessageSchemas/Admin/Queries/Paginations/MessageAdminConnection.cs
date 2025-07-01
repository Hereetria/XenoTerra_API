using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.MessageDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Queries.Paginations
{
    public class MessageAdminConnection(
        IReadOnlyList<Edge<ResultMessageWithRelationsAdminDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultMessageWithRelationsAdminDto>(edges, pageInfo, totalCount)
    {
    }
}
