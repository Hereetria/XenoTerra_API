using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.RecentChatsDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Queries.Paginations.Own
{
    public class RecentChatsOwnConnection(
        IReadOnlyList<Edge<ResultRecentChatsWithRelationsOwnDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultRecentChatsWithRelationsOwnDto>(edges, pageInfo, totalCount)
    {
    }
}
