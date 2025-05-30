﻿using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.StoryDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Queries.Paginations
{
    public class StoryAdminConnection(
        IReadOnlyList<Edge<ResultStoryWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultStoryWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
