﻿using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.RecentChatsDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Queries.Paginations
{
    public class RecentChatsSelfConnection(
        IReadOnlyList<Edge<ResultRecentChatsWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultRecentChatsWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
