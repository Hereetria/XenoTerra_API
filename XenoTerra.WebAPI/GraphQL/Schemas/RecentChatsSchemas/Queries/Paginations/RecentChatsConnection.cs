﻿using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.RecentChatsDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Queries.Paginations
{
    public class RecentChatsConnection(
        IReadOnlyList<Edge<ResultRecentChatsWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultRecentChatsWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
