﻿using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Queries.Paginations
{
    public class HighlightConnection(
        IReadOnlyList<Edge<ResultHighlightWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultHighlightWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
