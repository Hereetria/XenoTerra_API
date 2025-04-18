﻿using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Queries.Paginations
{
    public class SearchHistoryUserConnection(
        IReadOnlyList<Edge<ResultSearchHistoryUserWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultSearchHistoryUserWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
