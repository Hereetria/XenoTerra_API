using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.RecentChatsDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Queries.Paginations
{
    public class RecentChatsAdminConnection(
        IReadOnlyList<Edge<ResultRecentChatsWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultRecentChatsWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
