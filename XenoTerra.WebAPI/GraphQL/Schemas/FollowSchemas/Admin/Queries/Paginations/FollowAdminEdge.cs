﻿using XenoTerra.DTOLayer.Dtos.FollowDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Queries.Paginations
{
    public class FollowAdminEdge
    {
        public ResultFollowWithRelationsDto Node { get; set; } = null!;
        public string Cursor { get; set; } = string.Empty;
    }
}
