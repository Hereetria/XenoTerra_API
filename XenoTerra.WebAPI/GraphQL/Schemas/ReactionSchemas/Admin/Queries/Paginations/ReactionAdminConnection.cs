﻿using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.ReactionDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Queries.Paginations
{
    public class ReactionAdminConnection(
        IReadOnlyList<Edge<ResultReactionWithRelationsDto>> edges,
        ConnectionPageInfo pageInfo,
        int totalCount) : Connection<ResultReactionWithRelationsDto>(edges, pageInfo, totalCount)
    {
    }
}
