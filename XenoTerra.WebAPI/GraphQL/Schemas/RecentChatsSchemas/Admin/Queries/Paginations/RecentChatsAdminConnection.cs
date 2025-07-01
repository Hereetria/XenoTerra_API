using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.RecentChatsDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Queries.Paginations
{
    public class RecentChatsAdminConnection(
        IReadOnlyList<Edge<ResultRecentChatsWithRelationsAdminDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultRecentChatsWithRelationsAdminDto>(edges, pageInfo, totalCount)
    {
    }
}
